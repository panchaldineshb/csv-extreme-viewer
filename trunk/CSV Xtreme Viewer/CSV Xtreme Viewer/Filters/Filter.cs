using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSVXtremeLoader.Structures;

namespace CSVXtremeLoader
{
    interface Filter
    {
        bool IsLineValid(Line line);
    }
}
