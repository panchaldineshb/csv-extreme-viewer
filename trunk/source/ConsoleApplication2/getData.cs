using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class getData
    {
        public int RandomNumber(int max)
        {
            Random random = new Random(DateTime.UtcNow.Millisecond );
            return random.Next(max);       

        }

        public string Get_Data(String[] arreglo)
        {
            return arreglo[RandomNumber(arreglo.Length)];
        }
    }
}
