using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Timers;
using System.Threading;
using System.Text.RegularExpressions;
using CSVXtremeLoader.Loader;

namespace CSVXtremeLoader
{
    partial class CSVLoader
    {
        private StreamReader reader;
        private LoaderListener listener;
        private CSVStatistics statistics;
        private System.Timers.Timer timer;
        private Thread runningThread;
        private List<Filter> filters;
        private Metadata metadata;
        private Index lineNumberIndex;

        private bool isNewLineAvailable;
        private LinesBuffer buffer = new LinesBuffer();
        private Regex columnPattern;

        public CSVLoader(String filename, LinesBuffer buffer, CSVStatistics statistics)
        {
            reader = new StreamReader(new FileStream(filename, FileMode.Open, FileAccess.Read));

            columnPattern = new Regex("\\G([ ]*\"(?<t>(.|\\\\\")*?)\"[ ]*|(?<t>.*?))(,|$)", RegexOptions.Compiled | RegexOptions.ExplicitCapture);

            this.buffer = buffer;

            filters = new List<Filter>();
            lineNumberIndex = new Index(reader.BaseStream.Length);

            this.statistics = statistics;
            statistics.TotalBytes = reader.BaseStream.Length;
            statistics.bufferLength = 0;
            statistics.bufferPosition = 0;

            timer = new System.Timers.Timer(500);
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(UpdateStatus);

            runningThread = new Thread(new ThreadStart(RunIndexing));
        }

        public void Start()
        {
            timer.Enabled = true;
            runningThread.Start();
        }

        public void Stop()
        {
            if (runningThread.IsAlive)
            {
                runningThread.Interrupt();
                Ended();
            }
        }

        public void Pause()
        {

        }

        public void Resume()
        {

        }

        public void Ended()
        {
            UpdateStatus(null, null);
            timer.Enabled = false;
        }

        public void UpdateStatus(object source, ElapsedEventArgs e)
        {
            listener.OnStatisticsChanged(statistics);
            if (isNewLineAvailable)
            {
                listener.OnNewLinesAvailable(statistics);
            }
        }

        public void SetListener(LoaderListener listener)
        {
            this.listener = listener;
        }

        public void AddFilter(Filter filter)
        {
            filters.Add(filter);
        }

        public void removeAllFilters()
        {
            filters.Clear();
        }


        internal void SetMetatada(Metadata metadata)
        {
            this.metadata = metadata;
        }

    }
}
