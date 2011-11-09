using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSVData;

namespace CSVFilter
{
	public class NumberFilter : IFilter
    {
        string subType;
        string column;
        double value;

        public NumberFilter(string _subType, string _column, double _value)
        {
            this.subType = _subType;
            this.column = _column;
            this.value = _value;
        }

        public override bool IsLineValid(string rawLine, Metadata metadata)
        {
            Line line = ParseLine(rawLine, metadata);

            int index = 0;
            double tmp;
            if (metadata == null || line == null || metadata.columnNames.Length <= 0 || line.columns.Length <= 0)
                return false;
            foreach (string s in metadata.columnNames)
            {
                if (s.Equals(this.column))
                {
                    if (line.columns.Length <= index)
                        return false;
                    switch (this.subType)
                    {
                        case "MORE THAN":
                        {
                            if (Double.TryParse(line.columns[index].ToString(), out tmp) == false)
                                return false;
                            return (tmp > this.value);
                        }
                        case "MORE THAN OR EQUAL":
                        {
                            if (Double.TryParse(line.columns[index].ToString(), out tmp) == false)
                                return false;
                            return (tmp >= this.value);
                        }
                        case "EQUALS":
                        {
                            if (Double.TryParse(line.columns[index].ToString(),out tmp) == false)
                                return false;
                            return (tmp == this.value);
                        }
                        case "LESS THAN OR EQUAL":
                        {
                            if (Double.TryParse(line.columns[index].ToString(), out tmp) == false)
                                return false;
                            return (tmp <= this.value);
                        }
                        case "LESS THAN":
                        {
                            if (Double.TryParse(line.columns[index].ToString(), out tmp) == false)
                                return false;
                            return (tmp < this.value);
                        }
                    }
                }
                index++;
            }
            return false;
        }

    }
}