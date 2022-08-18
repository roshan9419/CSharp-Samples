using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSQCalculator.Fourth
{
    internal interface IBasicMath<T>
    {
        T Add(T numA, T numB);
        T Substract(T numA, T numB);
        T Multiply(T numA, T numB);
        T Divide(T numA, T numB);
    }
}
