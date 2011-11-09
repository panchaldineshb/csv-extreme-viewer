using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSVIndex;
using System.IO;
using System.Text.RegularExpressions;
using CSVData;

namespace CSVLoader
{
    public class LineReader
    {
        private Regex columnPattern = new Regex("\\G([ ]*\"(?<t>(.|\\\\\")*?)\"[ ]*|(?<t>.*?))(,|$)", RegexOptions.Compiled | RegexOptions.ExplicitCapture);

        private Stream reader;
        private Index index;
        private Metadata metadata;
        private bool closed;

        public LineReader(string filename, Index index, Metadata metadata)
        {
            reader = File.OpenRead(filename);
            this.index = index;
            this.metadata = metadata;
            closed = false;
        }

        public string GetRawLine(long lineNumber)
        {
            if (closed) return null;
            long position = index.GetLinePosition(lineNumber);
            if (position < 0) return null;
            reader.Position = position;
            return ReadLine();
        }

        public Line GetLine(long lineNumber)
        {
            if (closed) return null;
            long position = index.GetLinePosition(lineNumber);
            if (position < 0) return null;
            reader.Position = position;
            Line line = ParseLine(ReadLine(), metadata);
            line.LineNumber = lineNumber;
            return line;
        }

        private Line ParseLine(string rawLine, Metadata metadata)
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

        private string ReadLine()
        {
            StringBuilder builder = new StringBuilder(1000);
            byte[] buffer = new byte[1000];

            while (true)
            {
                int read = reader.Read(buffer, 0, buffer.Length);
                if (read <= 0) break;
                for (int i = 0; i < read; i++)
                {
                    if ((buffer[i] == '\r') | buffer[i] == '\n')
                    {
                        builder.Append(Encoding.UTF8.GetString(buffer, 0, i));
                        return builder.ToString();
                    }
                }
                builder.Append(Encoding.UTF8.GetString(buffer, 0, read));
            }

            if (builder.Length > 0) return builder.ToString();
            return null;
        }

        public void Close()
        {
            closed = true;
            reader.Close();
        }

    }

}
