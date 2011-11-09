using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace CSVLoader
{
    public class Saver
    {
        private StreamWriter writer;
        private LineReader lineReader;
        private CSVStatistics statistics;
        private Thread saverThread;

        public long CurrentLine;
        public long TotalLines;

        public Saver(string filename, LineReader lineReader, CSVStatistics statistics)
        {
            writer = new StreamWriter(File.Create(filename));
            this.lineReader = lineReader;
            this.statistics = statistics;
            TotalLines = statistics.LinesCount;
        }

        public void Start()
        {
            saverThread = new Thread(SaveProcess);
            saverThread.Name = "Saver Thread";
            saverThread.Start();
        }

        private void SaveProcess()
        {
            for (CurrentLine = 0; CurrentLine < statistics.FilteredLines; CurrentLine++)
            {
                string line = lineReader.GetRawLine(CurrentLine);
                writer.WriteLine(line);
            }
            writer.Close();
        }

    }
}
