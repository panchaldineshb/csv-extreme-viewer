using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVData
{
    public class Metadata
    {
        public int ColumnsCount { get; private set; }
        public string[] columnNames { get; private set; }

        public Metadata(int colums, string metadataLine)
        {
            ColumnsCount = colums;
            columnNames = metadataLine.Split(',');
        }
    }
}
