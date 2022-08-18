using System;

namespace Utils.Generators
{
    public class IDGenerator
    {
        public string NextID()
        {
            DateTime now = DateTime.Now;
            return $"{now.Second}{now.Minute}{now.Hour}{now.Month}{now.Year}";
        }

        private void TestMethod()
        {

        }
    }
}
