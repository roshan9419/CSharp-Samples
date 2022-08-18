using System;
using Utils.Generators;

namespace Utils.Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDGenerator idGen = new IDGenerator();
            Console.WriteLine(idGen.NextID());
        }
    }
}
