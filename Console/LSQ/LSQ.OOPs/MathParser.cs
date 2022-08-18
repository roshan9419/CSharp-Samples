namespace LSQ.OOPs
{
    class MathParser
    {
        IMath _IMath;
        BasicMath _BasicMath;

        // This can take both BasicMath as well as AdvancedMath
        public MathParser(IMath iMath)
        {
            _IMath = iMath;
        }

        // This can take both BasicMath as well as AdvancedMath
        public MathParser(BasicMath basicMath)
        {
            _BasicMath = basicMath;
        }
    }
}
