using System;
using LSQKYC.BackEnd;

namespace LSQKYC.FrontEnd
{
    internal class Startup
    {
        static void Main(string[] args)
        {
            KYCLogic kycLogic = new KYCLogic(
                "Roshan Kumar", 
                DateTime.Parse("11-11-2001"), 
                Gender.Male
            );

            Console.WriteLine("UserId: " + kycLogic.GetUserId());
        }
    }
}
