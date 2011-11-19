using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CSVData;

namespace CSVFilter
{
    public abstract class IFilter
    {
        protected Regex columnPattern = new Regex("\\G([ ]*\"(?<t>(.|\\\\\")*?)\"[ ]*|(?<t>.*?))(,|$)", RegexOptions.Compiled | RegexOptions.ExplicitCapture);

        public bool inverse = false;

        public abstract bool IsLineValid(String rawLine, Metadata metadata);

        protected Line ParseLine(string rawLine, Metadata metadata)
        {
            int columnsCount = metadata.ColumnsCount;
            Line line = new Line(columnsCount);

            // Parse the line
            int count = 0;
            Match match = columnPattern.Match(rawLine);
            while (match.Success)
            {
                line.columns[count] = match.Groups[1].Value.Trim();
                count++;
                match = match.NextMatch();
                if (count >= columnsCount) break;
            }

            return line;
        }

    }
}
