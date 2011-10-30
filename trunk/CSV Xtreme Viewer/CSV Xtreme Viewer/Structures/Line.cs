using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVXtremeLoader.Structures
{
    class Line
    {
        public Object[] columns { get; set; }
        public int LineNumber { get; set; }

        public Line(Object[] columns, int LineNumber)
        {
            this.columns = columns;
            this.LineNumber = LineNumber;
        }

        public Line(int columnsCount)
        {
            columns = new String[columnsCount];
            LineNumber = -1;
        }

    }
}
