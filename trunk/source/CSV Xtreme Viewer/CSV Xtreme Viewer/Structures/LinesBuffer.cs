using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using CSVXtremeLoader.Structures;

namespace CSVXtremeLoader
{
    class LinesBuffer
    {
        public const int READY = 0;
        public const int EMPTY = 1;
        public const int LOAD_REQUIRED = 2;

        public const int MID = 0;
        public const int SOF = 1;
        public const int EOF = 2;
        public int Flag { get; set; }

        private LinkedList<Line> buffer;
        private LinkedListNode<Line> currentNode;
        private int CurrentLine;


        public LinesBuffer()
        {
            buffer = new LinkedList<Line>();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddLine(Line line)
        {
            buffer.AddLast(line);
            if (currentNode == null)
            {
                currentNode = buffer.Last;
                CurrentLine = currentNode.Value.LineNumber;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public int GoTo(int lineNumber)
        {
            if (currentNode == null) return EMPTY;
            lineNumber++;
            if (lineNumber == CurrentLine) return READY;
            if (lineNumber < CurrentLine)
            {
                if ((lineNumber < buffer.First.Value.LineNumber) && ((Flag & SOF) != SOF)) return LOAD_REQUIRED;
                while (lineNumber < CurrentLine)
                {
                    if (currentNode == null) return LOAD_REQUIRED;
                    currentNode = currentNode.Previous;
                    CurrentLine = currentNode.Value.LineNumber;
                }
            }
            else
            {
                if ((lineNumber > buffer.Last.Value.LineNumber) && ((Flag & EOF) != EOF)) return LOAD_REQUIRED;
                while (lineNumber > CurrentLine)
                {
                    currentNode = currentNode.Next;
                    if (currentNode == null) return LOAD_REQUIRED;
                    CurrentLine = currentNode.Value.LineNumber;
                }
            }
            return READY;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public Line CurrentValue()
        {
            if (currentNode == null) return null;
            return currentNode.Value;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Clear()
        {
            buffer.Clear();
            currentNode = null;
            CurrentLine = -1;
        }

    }
}
