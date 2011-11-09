using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace CSVLoader
{
    partial class CSVLoader
    {
        private byte[] bufferA = new byte[1024*1024];
        private byte[] bufferB = new byte[1024*1024];
        private long bufferLength = 0;
        private byte[] bufferData = null;
        private Thread readerThread;


        private void runReader() {
            readerThread = new Thread(readerProcess);
            readerThread.Name = "Reader Thread";
            readerThread.Start();
        }

        private byte[] getBuffer()
        {
            return bufferData;
        }

        private long getBufferLength()
        {
            return bufferLength;
        }

        private void readerProcess()
        {
            barrier.SignalAndWait();

            byte[] buffer = bufferA;
            while (true)
            {
                long length;
                try
                {
                    length = inputStream.Read(buffer, 0, buffer.Length);
                }
                catch (IOException)
                {
                    break;
                }


                bufferData = buffer;
                bufferLength = length;
                if (length <= 0) break;
                statistics.BytesRead = inputStream.Position;

                try
                {
                    barrier.SignalAndWait();
                }
                catch (OperationCanceledException)
                {
                    break;
                }

                if (canceled) break;

                try
                {
                    barrier.SignalAndWait();
                }
                catch (OperationCanceledException)
                {
                    break;
                }

                if (buffer == bufferA) buffer = bufferB;
                else buffer = bufferA;
            }

            barrier.RemoveParticipant();
        }

    }
}
