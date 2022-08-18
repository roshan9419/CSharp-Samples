using System;

namespace LSQMath.Algebra
{
    internal class LSQMath
    {
        static void Main(string[] args)
        {
            // parent holding child class
            Algebra algebra = new AdvanceAlgebra();
            Console.WriteLine(algebra.Add(2, 3));
            Console.WriteLine(algebra.Div(12, 3));

            AdvanceAlgebra advAlgebra = new AdvanceAlgebra();
            Console.WriteLine(advAlgebra.Add(2, 3));
            Console.WriteLine(advAlgebra.Div(12, 3));
        }
    }

    // Overriding can be done using:
    // 1. virtual + override keywords
    // 2. using new keyword (ignores parent method)

    class Algebra
    {
        public virtual int Add(int numA, int numB)
        {
            return numA + numB;
        }

        public int Sub(int numA, int numB)
        {
            return numA - numB;
        }

        public int Mul(int numA, int numB)
        {
            return numA * numB;
        }

        public int Div(int numA, int numB)
        {
            return numA / numB;
        }

        public int Pow(int baseValue, int pow)
        {
            int res = 1;
            for (int i = 1; i <= pow; i++)
                res *= baseValue;
            return res;
        }
    }

    class AdvanceAlgebra: Algebra
    {
        public override int Add(int numA, int numB)
        {
            // any random logic to differentiate
            return (numA + numB) % 2 == 0 ? numA + numB : numA + numB + 1;
        }

        public new int Div(int numA, int numB)
        {
            // any random logic
            return (numA + numB) % 2 == 0 ? numA / numB : numA / numB + 1;
        }
    }
}
