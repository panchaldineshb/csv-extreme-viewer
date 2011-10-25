using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSVXtremeLoader.Structures;

namespace CSVXtremeLoader
{
	class TextFilter : IFilter
    {
        string subType;
        string column;
        string text;
    
        public TextFilter(string _subType, string _column, string _text)
        {
            this.subType = _subType;
            this.column = _column;
            this.text = _text;
        }

        public override bool IsLineValid(string rawLine, Metadata metadata)
        {
            Line line = ParseLine(rawLine, metadata);

            int index=0;
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
                        case "STARTS WITH":
                        {
                            return (line.columns[index].ToString().StartsWith(this.text)) ;
                        }
                        case "EQUALS":
                        {
                            return (line.columns[index].ToString().Equals(this.text));
                        }
                        case "CONTAINS":
                        {
                            return (line.columns[index].ToString().Contains(this.text));   
                        }
                        case "ENDS WITH":
                        {
                            return (line.columns[index].ToString().EndsWith(this.text));
                        }
                    }
                }
                index++;
            }
            return false;
        }
    }
}