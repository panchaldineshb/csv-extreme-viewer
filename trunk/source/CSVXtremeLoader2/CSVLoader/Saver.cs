using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using CSVData;

namespace CSVLoader
{
    public class Saver
    {
        private StreamWriter writer;
        private LineReader lineReader;
        private CSVStatistics statistics;
        private Metadata metadata;
        private Thread saverThread;

        public long CurrentLine;
        public long TotalLines;
        public bool Canceled { get; set; }

        public Saver(string filename, Metadata metadata, LineReader lineReader, CSVStatistics statistics)
        {
            writer = new StreamWriter(File.Create(filename));
            this.lineReader = lineReader;
            this.statistics = statistics;
            this.metadata = metadata;
            TotalLines = statistics.FilteredLines;
            Canceled = false;
        }

        public void Start()
        {
            saverThread = new Thread(SaveProcess);
            saverThread.Name = "Saver Thread";
            saverThread.Start();
        }

        private void SaveProcess()
        {
            writer.WriteLine(metadata.ToString());
            for (CurrentLine = 0; CurrentLine < statistics.FilteredLines; CurrentLine++)
            {
                if (Canceled) break;
                string line = lineReader.GetRawLine(CurrentLine);
                writer.WriteLine(line);
            }
            writer.Close();
        }

    }
}
