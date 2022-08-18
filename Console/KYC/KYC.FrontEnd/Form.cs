using System;
using KYC.BackEnd;

namespace KYC.FrontEnd
{
    internal class Form
    {
        static void Main(string[] args)
        {
            // accessing class libraries
            KYCAccount kycAccount = new KYCAccount(
                "Roshan Kumar",
                "Male",
                "+911234567890",
                DateTime.Parse("11-11-2001")
            );

            Console.WriteLine("UserId : " + kycAccount.GetUserId());
        }
    }
}
