using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal interface IGenInterface<T>
    {
        T GetTotalLength(T value);
    }

    class GenInterfaceClass : IGenInterface<int> // make class to generic if not to hardcode
    {
        public int GetTotalLength(int value)
        {
            return value.ToString().Length;
        }
    }
}
