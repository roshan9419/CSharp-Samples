namespace LSQ.OOPs
{
    class BasicMath : IMath
    {
        public virtual int Add(int numA, int numB)
        {
            return numA + numB;
        }
        
        public int Multiply(int numA, int numB)
        {
            return numA * numB;
        }
    }
}
