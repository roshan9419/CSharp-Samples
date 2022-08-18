using System;

namespace LSQCalculator.Second
{
    class AdvancedMath : BasicMath
    {
        internal double SquareRoot(int num)
        {
            return Math.Sqrt(num);
        }

        internal int Power(int baseValue, int pow)
        {
            int res = 1;
            for (int i = 1; i <= pow; i++)
                res *= baseValue;
            return res;
        }
    }
}
