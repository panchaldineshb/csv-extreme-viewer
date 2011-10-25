using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSVXtremeLoader.Structures;

namespace CSVXtremeLoader.Loader
{
    class Index
    {
        public const int intervalOfBytes = 1024 * 1024;
        private const int intervalOfBytes2 = intervalOfBytes * 2;
        private int indexSize;
        private int index;
        private List<IndexEntry> entries;
        private int lastBytePosition;
        private int lastLine;
        private int rejectedBytePosition;
        private int rejectedLine;

        public Index(long totalBytes)
        {
            indexSize = ((int)totalBytes / intervalOfBytes) + 1;
            entries = new List<IndexEntry>(indexSize);
            index = 0;
            lastBytePosition = -intervalOfBytes2;
            lastLine = -1;
        }

        private void AddEntry(int line, int bytePosition)
        {
            entries.Add(new IndexEntry(line, bytePosition));
            index++;
            lastLine = line;
            lastBytePosition = bytePosition;
        }

        public void AddToIndex(int line, int bytePosition)
        {
            int delta = bytePosition - lastBytePosition;
            if (delta < intervalOfBytes)
            {
                rejectedBytePosition = bytePosition;
                rejectedLine = line;
                return;
            }
            if ((delta > intervalOfBytes2) && (rejectedLine != -1))
            {
                AddEntry(rejectedLine, rejectedBytePosition);
            }
            AddEntry(line, bytePosition);
 
            rejectedBytePosition = 0;
            rejectedLine = -1;
        }

        public void FinishIndex()
        {
            if (rejectedLine != -1)
            {
                AddEntry(rejectedLine, rejectedBytePosition);
            }
            rejectedBytePosition = 0;
            rejectedLine = -1;
        }

        public int GetIndexOfLine(int lineNumber)
        {
            return FindClosestIndexToLine(0, index - 1, lineNumber);
        }

        private int FindClosestIndexToLine(int start, int end, int lineNumber)
        {
            if (end <= start) return start;
            if (entries.Count <= end) return start;

            int middle = (start + end) / 2;
            int value = entries[middle].LineNumber;
            if (lineNumber < value)
            {
                return FindClosestIndexToLine(start, middle - 1, lineNumber);
            }
            else if (lineNumber > value)
            {
                if (start + 1 == end)
                {
                    if (entries[end].LineNumber < lineNumber)
                    {
                        return end;
                    }
                    else
                    {
                        return start;
                    }
                }
                else
                {
                    return FindClosestIndexToLine(middle, end, lineNumber);
                }
            }
            else
            {
                return middle;
            }
        }

        public IndexEntry GetIndexEntry(int i)
        {
            if (i >= index) return null;
            return entries[i];
        }

    }
}
