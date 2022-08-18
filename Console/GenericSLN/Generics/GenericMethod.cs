
namespace Generics
{
    internal class GenericMethod
    {
        internal T1 GetSquare<T1>(T1 value)
        {
            return (dynamic)value * (dynamic)value;
        }

        internal int GetTotalLength<T1, T2>(T1 valueA, T2 valueB)
        {
            return (dynamic) valueA.ToString().Length + (dynamic)valueB.ToString().Length;
        }
    }
}
