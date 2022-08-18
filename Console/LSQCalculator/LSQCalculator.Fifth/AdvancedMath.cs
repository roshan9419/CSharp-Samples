using System;

namespace LSQCalculator.Fifth
{
    internal class AdvancedMath<T> : BasicMath<T>, IAdvancedMath<T>
    {
        public double SquareRoot(T num)
        {
            return Math.Sqrt((dynamic)num);
        }

        public T Power(T baseValue, int pow)
        {
            T res = (dynamic)1;
            for (int i = 1; i <= pow; i++)
                res *= (dynamic)baseValue;
            return res;
        }
    }
}
