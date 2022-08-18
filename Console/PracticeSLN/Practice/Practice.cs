using System;

namespace Practice
{
    // inheritance not possible
    // internal delegate int ParentDelegate(int valueA, int valueB);
    // internal delegate int ChildDelegate(int valueA, int valueB) : ParentDelegate;

    internal class Practice
    {
        private int _Side;
        public int Side
        {
            get { return _Side; }
            set { _Side = value * value; }
        }

        // delegate inside class
        internal delegate int ClassDelegate(int value);

        static void LambdaSwitchCase()
        {
            Func<int, string> lambdaWeekDay = (num) =>
            {
                switch (num)
                {
                    case 0:
                        return "Sunday";
                    case 1:
                        return "Monday";
                    case 2:
                        return "Tuesday";
                    case 3:
                        return "Wednesday";
                    case 4:
                        return "Thursday";
                    case 5:
                        return "Friday";
                    case 6:
                        return "Saturday";
                    default:
                        return "Invalid";
                }
            };

            Console.WriteLine(lambdaWeekDay(1));
            Console.WriteLine(lambdaWeekDay(9));
        }

    }

    class BaseMath<T>
    {
        //internal T Evaluate<T>(T numA, T numB, Func<T, T, T> executer) {
        //    return executer(numA, numB);
        //}

        internal T Add(T numA, T numB) => (dynamic)numA + numB;
        internal T Subtract(T numA, T numB) => (dynamic)numA - numB;
        internal T Multiply(T numA, T numB) => (dynamic)numA * numB;
        internal T Divide(T numA, T numB) => (dynamic)numA / numB;
    }

}
