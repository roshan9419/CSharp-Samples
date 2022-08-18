using System;

namespace LSQ.OOPs
{
    // Objects cannot be created of abstract classes
    abstract class Programmer
    {
        public abstract void DisplayLanguages();
        public void DoCoding()
        {
            Console.WriteLine("Abstract class methods can have body");
        }
    }
}
