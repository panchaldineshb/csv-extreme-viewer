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

namespace CSVXtremeLoader
{
    partial class CSVLoader
    {

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
                processLine(line, position);
            }
            lineNumberIndex.FinishIndex();

            ticks = System.Environment.TickCount - ticks;
            Console.WriteLine("Indexing (ms): " + ticks);

            Ended();
        }

        private void processLine(string rawLine, int position)
        {
            statistics.TotalLinesCount++;
            statistics.CurrentPosition++;

            if (rawLine.Length > 10000)
            {
                // TODO wrong line?
                return;
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
                    return;
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

        }

    }
}
