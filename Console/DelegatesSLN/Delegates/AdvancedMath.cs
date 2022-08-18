using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class AdvancedMath
    {
        internal static int Power(int baseValue, int pow)
        {
            int res = 1;
            for (int i = 1; i <= pow; i++)
                res *= baseValue;
            return res;
        }
    }
}
