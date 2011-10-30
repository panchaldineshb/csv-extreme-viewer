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
            statistics.Status = "Indexing";

            bool filtersExists = (filters.Count > 0);

            while (true)
            {
                long time1 = System.Environment.TickCount;
                int position = (int)reader.BaseStream.Position;
                string line = reader.ReadLine();
                statistics.timeOnReadLine += System.Environment.TickCount - time1;
                if (line == null) break;

                // Update the statistics
                statistics.BytesRead = reader.BaseStream.Position;
                statistics.TotalLinesCount++;
                statistics.CurrentPosition++;

                // Concentrate on the current line
                long time2 = System.Environment.TickCount;
                ProcessLineForIndexing(line, position);
                statistics.timeOnIndexing += System.Environment.TickCount - time2;


                if (refillRequired)
                {
                    long time3 = System.Environment.TickCount;
                    statistics.Status = "Buffering";
                    FillBufferFromLine(refillLineNumber);
                    statistics.Status = "Indexing";
                    statistics.timeOnBuffering += System.Environment.TickCount - time3;
                }
            }
            lineNumberIndex.FinishIndex();

            statistics.timeTotal = System.Environment.TickCount - ticks;
            Console.WriteLine("Total Time (ms): " + statistics.timeTotal);
            Console.WriteLine("TimeOnReadLine (ms): " + statistics.timeOnReadLine);
            Console.WriteLine("TimeOnAddToIndex (ms): " + statistics.timeOnAddToIndex);
            Console.WriteLine("TimeOnIndexing (ms): " + statistics.timeOnIndexing);
            Console.WriteLine("TimeOnFiltering (ms): " + statistics.timeOnFiltering);
            Console.WriteLine("TimeOnBuffering (ms): " + statistics.timeOnBuffering);
            long overhead = statistics.timeTotal - statistics.timeOnReadLine - statistics.timeOnAddToIndex - statistics.timeOnIndexing - statistics.timeOnFiltering - statistics.timeOnBuffering;
            Console.WriteLine("Overhead (ms): " + overhead);

            Ended();
        }

        private bool ProcessLineForIndexing(string rawLine, int position)
        {

            if (rawLine.Length > 10000)
            {
                statistics.CorruptedLines++;
                return false;
            }

            if (filtersAvailable)
            {
                long time1 = System.Environment.TickCount;
                // Apply all the filters to the line
                foreach (IFilter filter in filters)
                {
                    if (!filter.IsLineValid(rawLine, metadata))
                    {
                        statistics.timeOnFiltering += System.Environment.TickCount - time1;
                        return false;
                    }
                }
                statistics.timeOnFiltering += System.Environment.TickCount - time1;
            }

            long time2 = System.Environment.TickCount;
            statistics.FilteredLines++;
            lineNumberIndex.AddToIndex(statistics.FilteredLines, position);
            statistics.timeOnAddToIndex += System.Environment.TickCount - time2;

            // Fill the buffer if it is not empty
            if ((statistics.CurrentPosition > statistics.bufferPosition) && (statistics.bufferLength < statistics.bufferMaximumLength))
            {
                long time3 = System.Environment.TickCount;
                Line line = ParseLine(rawLine);
                line.LineNumber = statistics.FilteredLines;
                buffer.AddLine(line);
                statistics.bufferLength++;
                isNewLineAvailable = true;
                statistics.timeOnBuffering += System.Environment.TickCount - time3;
            }

            return true;
        }

        private Line ParseLine(string rawLine)
        {
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

            return line;
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
            if (listener != null) listener.OnNewLinesAvailable(statistics);
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
            buffer.Flag = LinesBuffer.MID;
            if (lineNumber <= 1) buffer.Flag = buffer.Flag | LinesBuffer.SOF;
            
            long size = 0;
            while (true)
            {
                long position = (int)reader.BaseStream.Position;
                string line = reader.ReadLine();
                if (line == null)
                {
                    buffer.Flag = buffer.Flag | LinesBuffer.EOF;
                    break;
                }
                line = line.Trim();
                if (line.Length == 0) continue;

                // Concentrate on the current line
                if (ProcessLineForBuffer(line, lineNumber, position))
                {
                    lineNumber++;
                    size += reader.BaseStream.Position - position;
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
                return false;
            }

            // Apply all the filters to the line
            foreach (IFilter filter in filters)
            {
                if (!filter.IsLineValid(rawLine, metadata))
                {
                    return false;
                }
            }

            // Parse the line
            Line line = ParseLine(rawLine);

            // Fill the buffer if it is not empty
            line.LineNumber = lineNumber;
            buffer.AddLine(line);
            statistics.bufferLength++;
            isNewLineAvailable = true;

            return true;
        }

    }
}
