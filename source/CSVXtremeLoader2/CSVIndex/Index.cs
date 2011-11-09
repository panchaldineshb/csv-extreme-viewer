using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;

namespace CSVIndex
{
    public class Index
    {
        private FileStream stream;
        private BinaryWriter writer;
        private BinaryReader reader;
        private long writePosition;
        private long readPosition;
        private bool closed;

        public Index(string filename)
        {
            stream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            writer = new BinaryWriter(stream);
            reader = new BinaryReader(stream);
            writePosition = 0;
            readPosition = 0;
            closed = false;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddToIndex(long position)
        {
            if (closed) return;
            long bytePosition = stream.Position;
            if (writePosition != bytePosition)
            {
                stream.Position = writePosition;
            }
            writer.Write(position);
            writePosition = stream.Position;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private bool GoToLine(long lineNumber)
        {
            if (closed) return false;
            long position = lineNumber * sizeof(long);
            if (position >= writePosition) return false;
            if (stream.Position != position)
            {
                stream.Position = position;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public long GetLinePosition(long lineNumber)
        {
            if (!GoToLine(lineNumber)) return -1;
            try
            {
                long position = reader.ReadInt64();
                readPosition = stream.Position;
                return position;
            }
            catch (EndOfStreamException) { }
            return -1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Close()
        {
            closed = true;
            stream.Close();
        }

    }
}
