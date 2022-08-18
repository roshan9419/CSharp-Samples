using System;
using LQS.Util.IDGenNext;

namespace LSQKYC.BackEnd
{
    public class KYCLogic: KYCData
    {
        public KYCLogic(string name, DateTime dob, Gender gender)
        {
            Name = name;
            DOB = dob;
            Gender = gender;
            //Id = GenerateId();
            Id = new IDGen().NextId(); // dll -> dynamic link library
        }

        private string GenerateId()
        {
            return (Name.Length * 10 + DOB.DayOfYear % 2).ToString();
        }

        public string GetUserId()
        {
            return Id;
        }
    }
}
