using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVXtremeLoader
{
    public class CSVStatistics
    {
        public int TotalLinesCount { get; set; }
        public long TotalBytes { get; set; }
        public long BytesRead { get; set; }
        public int CurrentPosition { get; set; }
        public int FilteredLines { get; set; }
        public int bufferMaximumLength { get; set; }
        public int bufferLength { get; set; }
        public int bufferPosition { get; set; }
        public string Status { get; set; }

        public CSVStatistics()
        {
            bufferMaximumLength = 100;
            Status = "Idle";
        }

    }
}
