using System;

namespace LSQCalculator.Fourth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdvancedMath<int> intCalc = new AdvancedMath<int>();
            Console.WriteLine("Add: " + intCalc.Add(2, 4));
            Console.WriteLine("Power: " + intCalc.Power(2, 3));

            AdvancedMath<float> floatCalc = new AdvancedMath<float>();
            Console.WriteLine("Add: " + floatCalc.Add(23.2f, 2.4f));
            Console.WriteLine("Power: " + floatCalc.Power(19.3f, 3));
        }
    }
}
