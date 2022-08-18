namespace Delegates
{
    internal class BasicMath
    {
        internal static int Add(int numA, int numB)
        {
            return numA + numB;
        }

        internal static int Substract(int numA, int numB)
        {
            return numA - numB;
        }
        
        internal static int Multiply(int numA, int numB)
        {
            return numA * numB;
        }
        
        internal static int Divide(int numA, int numB)
        {
            return numA / numB;
        }

        internal static int Power(int baseValue, int pow)
        {
            int res = 1;
            for (int i = 1; i <= pow; i++)
                res *= baseValue;
            return res;
        }
    }
}
