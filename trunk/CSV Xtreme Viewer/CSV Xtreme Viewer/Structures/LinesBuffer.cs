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
        public int GoTo(int index)
        {
            if (currentNode == null) return EMPTY;
            index++;
            if (index == CurrentLine) return READY;
            if (index < CurrentLine)
            {
                if (index < buffer.First.Value.LineNumber) return LOAD_REQUIRED;
                while (index < CurrentLine)
                {
                    currentNode = currentNode.Previous;
                    CurrentLine = currentNode.Value.LineNumber;
                }
            }
            else
            {
                if (index > buffer.Last.Value.LineNumber) return LOAD_REQUIRED;
                while (index> CurrentLine)
                {
                    currentNode = currentNode.Next;
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
