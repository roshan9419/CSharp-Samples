using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSQCalculator.Fifth
{
    internal abstract class BasicMathAbstract<T>
    {
        internal T Add(T numA, T numB)
        {
            return (dynamic)numA + (dynamic)numB;
        }
        internal T Substract(T numA, T numB)
        {
            return (dynamic)numA - (dynamic)numB;
        }
        internal abstract T Multiply(T numA, T numB);
        internal abstract T Divide(T numA, T numB);
    }
}
