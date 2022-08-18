using System;
using LSQCalcy.Operations;

namespace LSQCalcy.UI
{
    internal class Calcy
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Calcy!");
            
            RunAdvancedCalcy();
            RunBasicCalcy();
        }

        static void RunAdvancedCalcy()
        {
            AdvancedCalcy advancedCalcy = new AdvancedCalcy();
            Console.WriteLine($"Advanced Add: {advancedCalcy.Add(2, 3)}"); // inside basic
            Console.WriteLine($"Advanced Power: {advancedCalcy.Power(10, 4)}"); // inside advanced
        }

        static void RunBasicCalcy()
        {
            BasicCalcy basicCalcy = new BasicCalcy();
            Console.WriteLine($"Basic Add: {basicCalcy.Add(2, 3)}"); // inside basic
        }
    }
}
