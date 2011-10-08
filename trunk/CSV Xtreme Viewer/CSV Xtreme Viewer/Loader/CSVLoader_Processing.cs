using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using CSVXtremeLoader.Structures;
using System.Text.RegularExpressions;
using CSVXtremeLoader.Loader;

namespace CSVXtremeLoader
{
    partial class CSVLoader
    {
        private bool refillRequired = false;
        private int refillLineNumber = 0;

        private void RunIndexing()
        {
            reader.BaseStream.Position = 0;

            int ticks = System.Environment.TickCount;

            while (true)
            {
                int position = (int)reader.BaseStream.Position;
                string line = reader.ReadLine();
                if (line == null) break;
                line = line.Trim();
                if (line.Length == 0) continue;

                // Update the statistics
                statistics.BytesRead = reader.BaseStream.Position;

                // Concentrate on the current line
                ProcessLineForIndexing(line, position);

                if (refillRequired)
                {
                    FillBufferFromLine(refillLineNumber);
                }
            }
            lineNumberIndex.FinishIndex();

            ticks = System.Environment.TickCount - ticks;
            Console.WriteLine("Indexing (ms): " + ticks);

            Ended();
        }

        private bool ProcessLineForIndexing(string rawLine, int position)
        {
            statistics.TotalLinesCount++;
            statistics.CurrentPosition++;

            if (rawLine.Length > 10000)
            {
                // TODO wrong line?
                return false;
            }

            // Create a new empty line
            int columnsCount = metadata.ColumnsCount;
            Line line = new Line(columnsCount);

            // Parse the line
            int count = 0;
            Match match = columnPattern.Match(rawLine);
            while (match.Success)
            {
                line.columns[count] = match.Groups[1].Value;
                count++;
                match = match.NextMatch();
                if (count >= columnsCount) break;
            }

            // Apply all the filters to the line
            foreach (Filter filter in filters) {
                if (!filter.IsLineValid(line))
                {
                    return false;
                }
            }

            statistics.FilteredLines++;
            line.LineNumber = statistics.FilteredLines;
            lineNumberIndex.AddToIndex(line.LineNumber, position);

            // Fill the buffer if it is not empty
            if ((statistics.CurrentPosition > statistics.bufferPosition) && (statistics.bufferLength < statistics.bufferMaximumLength))
            {
                buffer.AddLine(line);
                statistics.bufferLength++;
                isNewLineAvailable = true;
            }

            return true;
        }

        public void RefillBuffer(int lineNumber)
        {
            if (runningThread.IsAlive)
            {
                if (refillRequired) return;
                refillLineNumber = lineNumber;
                refillRequired = true;
            }
            else
            {
                refillLineNumber = lineNumber;
                runningThread = new Thread(new ThreadStart(RunFillBuffer));
                runningThread.Start();
            }
        }

        private void RunFillBuffer()
        {
            FillBufferFromLine(refillLineNumber);
        }

        private void FillBufferFromLine(int lineNumber)
        {
            int originalPosition = (int)reader.BaseStream.Position;

            int index = lineNumberIndex.GetIndexOfLine(lineNumber);
            IndexEntry entry = lineNumberIndex.GetIndexEntry(index);
            long bytePosition = entry.BytePosition;
            reader.BaseStream.Position = bytePosition;
            lineNumber = entry.LineNumber;

            statistics.bufferLength = 0;
            buffer.Clear();

            long size = 0;
            while (true)
            {
                long position = (int)reader.BaseStream.Position;
                string line = reader.ReadLine();
                if (line == null) break;
                line = line.Trim();
                if (line.Length == 0) continue;

                // Concentrate on the current line
                if (ProcessLineForBuffer(line, lineNumber, position))
                {
                    lineNumber++;
                    size += position - reader.BaseStream.Position;
                    if (size > Index.intervalOfBytes) break;
                }
            }

            reader.BaseStream.Position = originalPosition;

            refillRequired = false;
        }

        private bool ProcessLineForBuffer(string rawLine, int lineNumber, long position)
        {
            if (rawLine.Length > 10000)
            {
                // TODO wrong line?
                return false;
            }

            // Create a new empty line
            int columnsCount = metadata.ColumnsCount;
            Line line = new Line(columnsCount);

            // Parse the line
            int count = 0;
            Match match = columnPattern.Match(rawLine);
            while (match.Success)
            {
                line.columns[count] = match.Groups[1].Value;
                count++;
                match = match.NextMatch();
                if (count >= columnsCount) break;
            }

            // Apply all the filters to the line
            foreach (Filter filter in filters)
            {
                if (!filter.IsLineValid(line))
                {
                    return false;
                }
            }

            // Fill the buffer if it is not empty
            line.LineNumber = lineNumber;
            buffer.AddLine(line);
            statistics.bufferLength++;
            isNewLineAvailable = true;

            return true;
        }

    }
}
