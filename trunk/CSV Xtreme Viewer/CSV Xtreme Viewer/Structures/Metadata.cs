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

        public Metadata(string metadataLine, string types )
        {
            ColumnsCount = metadataLine.Count(c => c == ',') + 1;
            columnNames = metadataLine.Split(',');
            columnType = types.Split(',');
        }
    }
}
