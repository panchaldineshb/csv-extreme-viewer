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
        public bool[] visible;

        public Metadata(int colums, string metadataLine)
        {
            ColumnsCount = colums;
            columnNames = metadataLine.Split(',');
            visible = new bool[ColumnsCount];
            for (int i = 0; i < visible.Length; i++)
                visible[i] = true;
        }
        public Metadata(string metadataLine)
        {
			//Still needs to check for "" with intermediate comma and trim each string
            columnNames = metadataLine.Split(',');
            ColumnsCount = columnNames.GetUpperBound(0) + 1;
            visible = new bool[ColumnsCount];
            for ( int i = 0; i < visible.Length ; i++ )
                visible[i] = true;
        }
    }
}
