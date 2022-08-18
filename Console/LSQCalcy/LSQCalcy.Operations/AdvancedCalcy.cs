using System;

namespace LSQCalcy.Operations
{
    // having all the basic operations + advanced operations
    public class AdvancedCalcy : BasicCalcy, IAdvancedOperations
    {
        public int Power(int num, int exponent)
        {
            int res = 1;
            for (int i = 1; i <= exponent; i++)
                res *= num;
            return res;
        }
    }
}
