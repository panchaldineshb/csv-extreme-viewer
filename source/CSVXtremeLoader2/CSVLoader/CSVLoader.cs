using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using CSVFilter;
using CSVData;
using CSVIndex;

namespace CSVLoader
{
    public partial class CSVLoader
    {
        private Barrier barrier = new Barrier(2);
        private CancellationTokenSource cancelation = new CancellationTokenSource();
        private FileStream inputStream;
        private List<IFilter> filters;
        private CSVStatistics statistics;
        private Metadata metadata;
        private Index index;
        private LineReader lineReader;
        private string filename;
        private bool canceled;
        private bool finished;
        public bool IgnoreFirstLine { get; set; }

        public CSVLoader(string filename)
        {
            this.filename = filename;
            inputStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            filters = new List<IFilter>();
            statistics = new CSVStatistics();
            index = new Index(filename + ".index");

            statistics.TotalBytes = inputStream.Length;
            canceled = false;
        }

        public void Start()
        {
            runReader();
            runProcessing();
            statistics.Status = "Processing";
            finished = false;
        }

        public void AddFilter(IFilter filter)
        {
            filters.Add(filter);
        }

        public void SetMetadata(Metadata metadata)
        {
            this.metadata = metadata;
        }

        public Metadata GetMetadata()
        {
            return this.metadata;
        }

        public LineReader GetLineReader()
        {
            if (lineReader == null) lineReader = new LineReader(filename, index, metadata);
            return lineReader;
        }

        public CSVStatistics GetStatistics()
        {
            return statistics;
        }

        public Saver GetSaver(string filename)
        {
            return new Saver(filename, metadata, lineReader, statistics);
        }

        public void Close()
        {
            canceled = true;
            index.Close();
            lineReader.Close();
        }

    }
}
