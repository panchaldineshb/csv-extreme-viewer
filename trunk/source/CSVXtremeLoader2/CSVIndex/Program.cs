using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CSVIndex
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            long ticks = System.Environment.TickCount;

            Index index = new Index("Test.index");
            for (int i = 1; i < 10000000; i++)
            {
                index.AddToIndex(i);
            }

            for (int i = 1; i < 10000000; i++)
            {
                if (index.GetLinePosition(i) != i)
                {
                    Console.WriteLine("Error en linea: " + i);
                    break;
                }
            }

            ticks = System.Environment.TickCount - ticks;
            Console.WriteLine("Time (ms): " + ticks);
        }
    }
}
