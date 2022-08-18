using LSQInterface.Data;
using System;

namespace LSQInterface.Logic
{
    internal class Startup
    {
        static void Main(string[] args)
        {
            FullKYC fullKYC = new FullKYC();
            fullKYC.TakeDetails();
            fullKYC.DisplayDetails();
        }
    }

    class FullKYC : IPayTmKYC
    {
        PayTmKYC paytmKyc;

        public void DisplayDetails()
        {
            Console.WriteLine("\nDetails: ");
            if (paytmKyc == null)
            {
                Console.Write("Not Available");
                return;
            }
            Console.WriteLine($"Name: {paytmKyc.GetName()}");
            Console.WriteLine($"Age: {paytmKyc.GetAge()}");
        }

        public void TakeDetails()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            paytmKyc = new PayTmKYC(age, name);
        }

        public bool VerifyDetails()
        {
            return true;
        }
    }
}
