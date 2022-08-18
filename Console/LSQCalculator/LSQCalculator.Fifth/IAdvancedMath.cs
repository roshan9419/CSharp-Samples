using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSQCalculator.Fifth
{
    internal interface IAdvancedMath<T>
    {
        double SquareRoot(T num);
        T Power(T baseValue, int pow);
    }
}
