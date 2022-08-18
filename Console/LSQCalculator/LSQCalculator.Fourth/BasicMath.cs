namespace LSQCalculator.Fourth
{
    class BasicMath<T>: IBasicMath<T>
    {
        public T Add(T numA, T numB)
        {
            return (dynamic)numA + (dynamic)numB;
        }

        public T Substract(T numA, T numB)
        {
            return (dynamic)numA - (dynamic)numB;
        }

        public T Multiply(T numA, T numB)
        {
            return (dynamic)numA * (dynamic)numB;
        }

        public T Divide(T numA, T numB)
        {
            return (dynamic)numA / (dynamic)numB;
        }
    }
}
