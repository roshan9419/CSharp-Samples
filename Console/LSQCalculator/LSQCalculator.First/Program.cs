using System;

namespace LSQCalculator.First
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            Console.WriteLine("Add: " + calc.Add(2, 4));
            Console.WriteLine("Power: " + calc.Power(2, 3));
        }
    }

    class Calculator
    {
        internal int Add(int numA, int numB)
        {
            return numA + numB;
        }

        internal int Substract(int numA, int numB)
        {
            return numA - numB;
        }

        internal int Multiply(int numA, int numB)
        {
            return numA * numB;
        }

        internal int Divide(int numA, int numB)
        {
            return numA / numB;
        }
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
