using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVLoader
{
    public class CSVStatistics
    {
        
        public long LinesCount { get; set; }
        public long BytesRead { get; set; }
        public long TotalBytes { get; set; }
        public long FilteredLines { get; set; }
        public long CorruptedLines { get; set; }
        public string Status { get; set; }

        public long timeTotal { get; set; }
        public long timeOnAddToIndex { get; set; }
        public long timeOnIndexing { get; set; }
        public long timeOnReadLine { get; set; }
        public long timeOnFiltering { get; set; }
        public long timeOnBuffering { get; set; }

        public CSVStatistics()
        {
            Status = "Idle";
        }

    }
}
