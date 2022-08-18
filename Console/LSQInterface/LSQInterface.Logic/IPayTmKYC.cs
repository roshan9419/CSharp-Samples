using System;

namespace LSQInterface.Logic
{
    internal interface IPayTmKYC
    {
        public void TakeDetails();
        public bool VerifyDetails();
        public void DisplayDetails();
    }
}
