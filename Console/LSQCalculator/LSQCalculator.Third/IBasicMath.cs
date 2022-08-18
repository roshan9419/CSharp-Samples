using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSQCalculator.Third
{
    internal interface IBasicMath
    {
        int Add(int numA, int numB);
        int Substract(int numA, int numB);
        int Multiply(int numA, int numB);
        int Divide(int numA, int numB);
    }
}
