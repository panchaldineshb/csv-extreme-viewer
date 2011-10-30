using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVXtremeLoader.Loader
{
    class IndexEntry
    {
        public int LineNumber { get; set; }
        public int BytePosition { get; set; }

        public IndexEntry(int LineNumber, int BytePosition)
        {
            this.LineNumber = LineNumber;
            this.BytePosition = BytePosition;
        }

    }
}
