using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal static class Extensions
    {
        internal static int FindSquare(this int data, Func<int, int> executer)
        {
            return executer(data);
        }

        internal static string ConvertToString(this int data, Func<int, string> executer)
        {
            return executer(data);
        }

        internal static T SquareElements<T>(this T arrData, Func<T, T> executer)
        {
            return executer(arrData);
        }
    }
}
