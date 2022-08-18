namespace LSQ.OOPs
{
    class AdvancedMath : BasicMath
    {
        public override int Add(int numA, int numB)
        {
            return numA * 10 + numB * 10;
        }

        public int Power(int baseNum, int pow)
        {
            int res = 1;
            for (int i = 1; i <= pow; i++)
                res *= baseNum;
            return res;
        }
    }
}
