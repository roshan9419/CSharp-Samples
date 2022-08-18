namespace LSQCalculator.Third
{
    class BasicMath: IBasicMath
    {
        public int Add(int numA, int numB)
        {
            return numA + numB;
        }

        public int Substract(int numA, int numB)
        {
            return numA - numB;
        }

        public int Multiply(int numA, int numB)
        {
            return numA * numB;
        }

        public int Divide(int numA, int numB)
        {
            return numA / numB;
        }
    }
}
