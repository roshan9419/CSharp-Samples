using System;

namespace LSQCalculator.Second
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdvancedMath calc = new AdvancedMath();
            Console.WriteLine("Add: " + calc.Add(2, 4));
            Console.WriteLine("Power: " + calc.Power(2, 3));
        }
    }
}
