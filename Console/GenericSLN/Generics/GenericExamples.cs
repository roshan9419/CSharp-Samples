using System;

namespace Generics
{
    internal class GenericExamples
    {
        static void Main(string[] args)
        {
            #region temporary
            GenericClassExample();
            GenericMethodsExample();
            GenericClassInheritanceExample();
            GenericInterfaceExample();
            GenericClassOverloadingExample();
            GenericAbstractClassExample();
            #endregion

            var method = new GenericMethodRevision();
            Console.WriteLine(method.ConvertToString(10, "Hello", 29.45f));

            var list = new GenericCollection<string>();
            list.PushItem("A");
            list.PushItem("B");
            list.PushItem("C");
            list.PushItem("D");

            Console.WriteLine(list.SearchItem("C"));
            Console.WriteLine(list.SearchItem("E"));
        }

        static void GenericClassExample()
        {
            GenericMath<int> genIntMath = new GenericMath<int>();
            Console.WriteLine(genIntMath.Add(2, 4)); // works
            Console.WriteLine(genIntMath.Power(2, 3)); // works

            GenericMath<float> genFloatMath = new GenericMath<float>();
            Console.WriteLine(genFloatMath.Add(2.2F, 4.12F)); // works
            Console.WriteLine(genFloatMath.Power(19.44F, 3)); // works

            GenericMath<string> genStringMath = new GenericMath<string>();
            Console.WriteLine(genStringMath.Add("Roshan ", "Kumar")); // works
            // Console.WriteLine(genStringMath.Multiply("Lead", "Squared")); // not works (runtime error)
            // Console.WriteLine(genStringMath.Power("C#", 10)); // not works

            GenericMath<Dummy> genDummyMath = new GenericMath<Dummy>();
            Console.WriteLine(genDummyMath.Add(new Dummy(), new Dummy(10)));
        }

        static void GenericMethodsExample()
        {
            // Generic method inside generic class
            GenericMath<int> genMath = new GenericMath<int>();
            genMath.GetRectangleArea<float>(10, 50.23f);

            // Generic method inside normal class
            GenericMethod genMethod = new GenericMethod();
            genMethod.GetSquare<int>(10);
            genMethod.GetTotalLength<string, int>("Roshan Kumar", 1234);
        }

        static void GenericClassInheritanceExample()
        {
            // generic child class
            Console.WriteLine(new GenericChild<string>().WhoIAm());

            // generic parent class
            Console.WriteLine(new GenericParent<int, float>().WhoIAm());

            // generic grandparent class
            Console.WriteLine(new GenericGrandParent<GenericMath<char>>().WhoIAm());
        }

        static void GenericInterfaceExample()
        {
            GenInterfaceClass genInterfaceClass = new GenInterfaceClass();
            genInterfaceClass.GetTotalLength(1234);
        }

        static void GenericClassOverloadingExample()
        {
            new LeadSquared<int>();
            new LeadSquared<int, float>();
            new LeadSquared<int, float, string>();
            new LeadSquared<string, double, Dummy>();
        }

        static void GenericAbstractClassExample()
        {
            GenericAbstractChild<int, string> genericAbstractChild = new GenericAbstractChild<int, string>();
            genericAbstractChild.SwapValues(1234, "C Sharp");
        }
    }
}
