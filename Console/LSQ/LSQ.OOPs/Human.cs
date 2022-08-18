using System;

namespace LSQ.OOPs
{
    // Inheriting Abstract class and implementing the methods
    class Human : Programmer
    {
        public override void DisplayLanguages()
        {
            Console.WriteLine("Languages Known: Dart, Python, Javascript, Java, C++, etc");
        }
    }
}
