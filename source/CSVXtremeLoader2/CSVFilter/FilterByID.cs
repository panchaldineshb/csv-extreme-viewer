using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSVData;

namespace CSVFilter
{
    public class FilterByID : IFilter
    {
        private int column;
        private int minID;
        private int maxID;

        public FilterByID(int column, int minID, int maxID)
        {
            this.column = column;
            this.minID = minID;
            this.maxID = maxID;
        }

        public override bool IsLineValid(string rawLine, Metadata metadata)
        {
            Line line = ParseLine(rawLine, metadata);
            try
            {
                int id = Convert.ToInt32(line.columns[column]);
                if (id < minID) return false;
                if (id > maxID) return false;
                return true;
            }
            catch (FormatException) { return false; }
        }
    }
}
