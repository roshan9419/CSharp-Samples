using System;
using KYC.BackEnd.Data;

namespace KYC.BackEnd
{
    public class KYCAccount : KYCBase
    {
        public KYCAccount(string name, string gender, string phoneNumber, DateTime dateOfBirth)
        {
            Name = name;
            Gender = gender;
            PhoneNumber = phoneNumber; // must be of format +911234567890
            DateOfBirth = dateOfBirth;
            GenerateId();
        }

        private void GenerateId()
        {
            UserId = $"{Name.ToLower()}_{DateOfBirth.Millisecond}_{Gender.ToLower()[0]}";
        }

        public string GetUserId()
        {
            return UserId;
        }
    }
}
