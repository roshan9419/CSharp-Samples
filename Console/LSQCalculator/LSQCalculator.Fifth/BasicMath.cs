namespace LSQCalculator.Fifth
{
    class BasicMath<T>: BasicMathAbstract<T>
    {
        internal override T Multiply(T numA, T numB)
        {
            return (dynamic)numA * (dynamic)numB;
        }

        internal override T Divide(T numA, T numB)
        {
            return (dynamic)numA / (dynamic)numB;
        }
    }
}
