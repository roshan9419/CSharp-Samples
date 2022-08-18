using System;

namespace LSQ.OOPs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AbstractClassExample();
            InterfaceExample();
            StaticClassExample();
        }

        static void AbstractClassExample()
        {
            Human human = new Human();
            human.DisplayLanguages();
            human.DoCoding();
        }

        static void InterfaceExample()
        {
            IMath basicIMath = new BasicMath();  // only have Add method
            IMath advIMath = new AdvancedMath(); // only have Add method which is overriden

            Console.WriteLine($"Basic Add: {basicIMath.Add(1, 2)}");
            Console.WriteLine($"Advance Add: {advIMath.Add(1, 2)}");

            MathParser basicMathParser = new MathParser(new BasicMath());
            MathParser advanceMathParser = new MathParser(new AdvancedMath());
        }

        static void StaticClassExample()
        {
            int num = 1234;
            Console.WriteLine($"IsPositive: {num.IsPositive()}"); // 1st way to call static method

            string name = null;
            Console.WriteLine($"IsValid: {Utils.IsValid(name)}"); // 2nd way to call static method
        }
    }
}
