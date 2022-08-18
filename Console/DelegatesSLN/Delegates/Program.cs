using System;

namespace Delegates
{
    internal delegate void VoidAction(int valueA, int valueB); // normal
    internal delegate void VoidAction<in T1, in T2>(T1 valueA, T2 valueB); // generic

    internal delegate int Function(int numA, int numB); // normal
    internal delegate T3 Function<in T1, in T2, out T3>(T1 valueA, T2 valueB); // generic

    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> advFunc = AdvancedMath.Power;
            Console.WriteLine("Power: " + advFunc(10, 3));

            advFunc = (num, _) =>
            {
                int res = 1;
                for (int i = 1; i <= num; i++)
                    res *= i * num;
                return res;
            };
            Console.WriteLine("Factorial: " + advFunc(5, 0));

            DelegatesUsingLambdas();
        }

        static void DelegatesUsingLambdas()
        {
            // 2 args and int return type
            Func<int, int, int> funcTypeA;

            // add
            funcTypeA = (a, b) => a + b;
            Console.WriteLine("Add: " + funcTypeA(10, 20));

            // multiply
            funcTypeA = (a, b) => a * b;
            Console.WriteLine("Multiply: " + funcTypeA(10, 20));

            // power
            funcTypeA = (baseValue, pow) =>
            {
                int res = 1;
                for (int i = 1; i <= pow; i++)
                    res *= baseValue;
                return res;
            };
            Console.WriteLine("Power: " + funcTypeA(10, 20));


            // 1 arg and int return type
            Func<int, int> funcTypeB;

            // factorial
            funcTypeB = (num) =>
            {
                int res = 1;
                for (int i = 1; i <= num; i++)
                    res *= i * num;
                return res;
            };
            Console.WriteLine("Factorial: " + funcTypeB(5));

            // even(0) or odd(1)
            funcTypeB = (num) => num % 2;
            Console.WriteLine("Even or Odd: " + funcTypeB(58));


            // string operations
            Func<string, string, string> funcTypeC = (a, b) => a + b; // concatination
            Console.WriteLine("Concat: " + funcTypeC("Roshan ", "Kumar"));


            // passing function body as parameter
            int side = 20;
            
            Console.WriteLine(side.FindSquare(x => x * x));

            Console.WriteLine(side.ConvertToString(
                x => {
                    x *= 10;
                    return "Number is: " + x.ToString();
                }
            ));


            int[] nums = { 10, 20, 30, 40, 50 };
            Console.WriteLine("\nBefore: ");
            PrintArray(nums);

            int[] squaredNums = nums.SquareElements((nums) => 
                                                      {
                                                        for (int i = 0; i < nums.Length; i++)
                                                            nums[i] *= nums[i];
                                                        return nums;
                                                      });

            Console.WriteLine("\nAfter: ");
            PrintArray(squaredNums);
        }

        static void PrintArray<T>(T[] array)
        {
            foreach (T item in array)
                Console.Write(item + " ");
        }

        static void UsingOurOwnDelegate()
        {
            // return type delegates
            Function commonFunc;

            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 0) commonFunc = BasicMath.Add;
            else if (choice == 1) commonFunc = BasicMath.Substract;
            else if (choice == 2) commonFunc = BasicMath.Multiply;
            else commonFunc = BasicMath.Divide;

            Console.WriteLine("Result: " + commonFunc(10, 20));

            Function<string, string, int> strFunction = (strA, strB) => (strA + strB).Length;
            Console.WriteLine("String length: " + strFunction("Roshan", "Kumar"));

            // void delegates
            VoidAction voidAction = MyVoidMethod;
            voidAction(10, 20);

            VoidAction<string, string> voidStrAction = MyVoidMethod;
            voidStrAction("Roshan", "Kumar");
        }

        static void UsingExistingDelegates()
        {
            // void delegates, total 16 available
            Action<int> action1 = (e) => Console.WriteLine("Value: " + e);
            Action<string, float> action2 = MyVoidMethod;

            action1(10);
            action2("Anything", 10f);

            // return type delegates, total 17 available
            Func<int> func1 = () => 1; // no-args
            Func<int, int> func2 = (e) => e + 10; // 1-arg
            Func<int, int, string> func3 = (a, b) => (a + b) % 2 == 0 ? "Even" : "Odd"; // 2-arg

            Console.WriteLine(func1());
            Console.WriteLine(func2(10));
            Console.WriteLine(func3(10, 20));
        }

        static void MyVoidMethod<T1, T2>(T1 valueA, T2 valueB)
        {
            Console.WriteLine("This is void method");
        }
    }
}
