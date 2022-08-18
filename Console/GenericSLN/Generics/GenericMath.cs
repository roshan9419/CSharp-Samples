namespace Generics
{
    class GenericMath<E>
    {
        internal E Add(E valueA, E valueB)
        {
            return (dynamic)valueA + (dynamic)valueB;
        }

        internal E Subtract(E valueA, E valueB)
        {
            return (dynamic)valueA - (dynamic)valueB;
        }

        internal E Multiply(E valueA, E valueB)
        {
            return (dynamic)valueA * (dynamic)valueB;
        }

        internal E Divide(E valueA, E valueB)
        {
            return (dynamic)valueA / (dynamic)valueB;
        }

        internal E Square(E value)
        {
            return (dynamic)value * (dynamic)value;
        }

        internal E Power(E value, int pow)
        {
            E res = value;
            for (int i = 2; i < pow; i++)
                res *= (dynamic) value;
            return res;
        }

        internal F GetRectangleArea<F>(E sideA, F sideB)
        {
            return (dynamic)sideA * (dynamic)sideB;
        }
    }
}
