using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CSVLoader;
using CSVFilter;
using CSVData;
using System.Threading;

namespace CSVLoader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CSVLoader loader = new CSVLoader("C:\\Users\\Usuario\\Desktop\\Testing\\File3.csv");
            loader.AddFilter(new FilterByID(0, 1000000, 1500000));
            loader.SetMetadata(new Metadata(5, "a,b,c,d,e"));
            loader.Start();
            LineReader reader = loader.GetLineReader();
            CSVStatistics statistics = loader.GetStatistics();

            Random rand = new Random();
            while (true)
            {
                Thread.Sleep(1000);
                if (statistics.FilteredLines > 0)
                {
                    long value = (long)(rand.NextDouble() * statistics.FilteredLines);
                    Line line = reader.GetLine(value);
                    Console.WriteLine("Line: " + value + ", A: " + line.columns[0] + ", B: " + line.columns[1]);
                }
                else
                {
                    Console.WriteLine("Empty");
                }

            }

        }
    }
}
