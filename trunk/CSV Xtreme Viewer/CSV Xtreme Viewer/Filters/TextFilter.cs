using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSVXtremeLoader.Structures;

namespace CSVXtremeLoader
{
	class TextFilter : Filter, IFilter
    {
        string text;
    
        public TextFilter(string _subType, string _column, string _text)
        {
            this.subType = _subType;
            this.column = _column;
            this.text = _text;
        }
        bool IFilter.IsLineValid(Line line, Metadata metadata)
        {
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