
namespace LSQCalcy.Operations
{
    public class BasicCalcy : IBasicOperations
    {
        public int Add(int numA, int numB)
        {
            return numA + numB;
        }

        public int Subtract(int numA, int numB)
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

        public int Modulo(int numA, int numB)
        {
            return numA % numB;
        }
    }
}
