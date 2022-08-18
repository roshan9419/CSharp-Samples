using System;

namespace LSQCalculator.Third
{
    class AdvancedMath : BasicMath, IAdvancedMath
    {
        public double SquareRoot(int num)
        {
            return Math.Sqrt(num);
        }

        public int Power(int baseValue, int pow)
        {
            int res = 1;
            for (int i = 1; i <= pow; i++)
                res *= baseValue;
            return res;
        }
    }
}
