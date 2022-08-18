using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class GenericMethodRevision
    {
        internal T GetArea<T>(T length, T breadth)
        {
            return (dynamic)length * breadth;
        }

        internal string ConvertToString<T1, T2, T3>(T1 value1, T2 value2, T3 value3)
        {
            return value1.ToString() + value2.ToString() + value3.ToString();
        }
    }
}
