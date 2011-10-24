using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSVXtremeLoader.Structures;

namespace CSVXtremeLoader
{
    interface IFilter
    {
        bool IsLineValid(Line line, Metadata metadata);
    }
}
