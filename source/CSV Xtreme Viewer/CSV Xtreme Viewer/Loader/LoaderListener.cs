using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVXtremeLoader
{
    interface LoaderListener
    {
        void OnStatisticsChanged(CSVStatistics statistics);
        void OnNewLinesAvailable(CSVStatistics statistics);
        void OnCorruptedFile(string message);
    }
}
