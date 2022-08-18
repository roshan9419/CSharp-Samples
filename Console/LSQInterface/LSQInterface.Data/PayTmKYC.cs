using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSQInterface.Data
{
    // inheriting class as well as interface
    public class PayTmKYC: KYC, IIdGenerate
    {
        public PayTmKYC(int age, string name)
        {
            Age = age;
            Name = name;
            Id = GenerateId();
        }

        // now it's no longer private
        public int GenerateId()
        {
            return (Age + 18) % Name.Length;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetAge()
        {
            return Age;
        }
    }
}
