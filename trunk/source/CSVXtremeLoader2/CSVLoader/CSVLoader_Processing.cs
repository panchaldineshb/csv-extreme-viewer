using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CSVFilter;
using CSVIndex;

namespace CSVLoader
{
    partial class CSVLoader
    {
        private Thread processingThread;
        private long lineCount;

        private void runProcessing()
        {
            processingThread = new Thread(processingProcess);
            processingThread.Name = "Processing Thread";
            processingThread.Start();
        }

        private void processingProcess()
        {
            barrier.SignalAndWait();

            Encoding utf8 = Encoding.UTF8;
            lineCount = 0;
            long ticks = System.Environment.TickCount;

            string line = null;
            bool posibleEnter = false;
            long byteBasePosition = 0;
            long bytePosition = 0;
            long length = 0;

            while (true)
            {
                barrier.SignalAndWait();

                if (canceled)
                {
                    line = null;
                    break;
                }

                byteBasePosition += length;
                byte[] buffer = getBuffer();
                length = getBufferLength();
                if (length <= 0) break;

                barrier.SignalAndWait();

                int lastIndex = 0;
                if (posibleEnter && (buffer[0] == '\n'))
                {
                    lastIndex++;
                    bytePosition = byteBasePosition + lastIndex;
                }
                posibleEnter = false;
                for (int i = lastIndex; i < length; i++)
                {
                    if (buffer[i] == '\r')
                    {
                        if (line != null) line = line + utf8.GetString(buffer, lastIndex, i - lastIndex);
                        else line = utf8.GetString(buffer, lastIndex, i - lastIndex);
                        ProcessLine(line, bytePosition);
                        line = null;
                        if ((i + 1 < length) && (buffer[i + 1] == '\n'))
                        {
                            i++;
                        }
                        else
                        {
                            posibleEnter = true;
                        }
                        lastIndex = i + 1;
                        bytePosition = byteBasePosition + lastIndex;
                        continue;
                    }
                    if (buffer[i] == '\n')
                    {
                        if (line != null) line = line + utf8.GetString(buffer, lastIndex, i - lastIndex);
                        else line = utf8.GetString(buffer, lastIndex, i - lastIndex);
                        ProcessLine(line, bytePosition);
                        line = null;
                        lastIndex = i + 1;
                        bytePosition = byteBasePosition + lastIndex;
                        continue;
                    }
                }
                if (lastIndex < length)
                {
                    if (line == null) line = utf8.GetString(buffer, lastIndex, (int)(length - lastIndex));
                    else line = line + utf8.GetString(buffer, lastIndex, (int)(length - lastIndex));
                }

            }

            if (line != null)
            {
                ProcessLine(line, bytePosition);
                line = null;
            }


            Console.WriteLine("Line Count: " + lineCount);
            long delta = System.Environment.TickCount - ticks;
            Console.WriteLine("Total Time (ms): " + delta);
            statistics.Status = "Idle";
            finished = true;

            barrier.RemoveParticipant();
        }

        private void ProcessLine(string line, long position)
        {
            statistics.LinesCount++;

            bool isValid = true;
            if (filters.Count > 0)
            {
                foreach (IFilter filter in filters) {
                    if (!filter.IsLineValid(line, metadata))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (isValid)
            {
                lineCount++;
                statistics.FilteredLines = lineCount;
                index.AddToIndex(position);
            }
        }


    }
}
