using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVXtremeLoader
{
    class Metadata
    {
        public int ColumnsCount { get; private set; }
        public string[] columnNames { get; private set; }
        public string[] columnType { get; private set; }

        public Metadata(int colums, string metadataLine, string types )
        {
            ColumnsCount = colums;
            columnNames = metadataLine.Split(',');
            columnType = types.Split(',');
        }
        public Metadata(string metadataLine)
        {
            columnNames = metadataLine.Split(',');
            ColumnsCount = columnNames.GetUpperBound(0) + 1;
        }
    }
}
