using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSVData;

namespace CSVFilter
{
    public class RangeFilter : IFilter
    {
        private string column;
        private long minData;
        private long maxData;

        public RangeFilter(string column, long minData, long maxData)
        {
            this.column = column;
            this.minData = minData;
            this.maxData = maxData;
        }

        public override bool IsLineValid(string rawLine, Metadata metadata)
        {
            Line line = ParseLine(rawLine, metadata);
            int index = 0;
            try
            {
                foreach (string s in metadata.columnNames)
                {
                    if (line.columns.Length <= index)
                        return false;
                    if (s.Equals(this.column))
                    {
                        long id = Convert.ToInt64(line.columns[index]);
                        if (id < minData) return false;
                        if (id > maxData) return false;
                        return true;
                    }
                    index++;
                }
                return false;
            }
            catch (FormatException) { return false; }
        }
    }
}
