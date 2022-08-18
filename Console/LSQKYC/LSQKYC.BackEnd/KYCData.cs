using System;

namespace LSQKYC.BackEnd
{
    public class KYCData
    {
        // normal variable
        protected string Id;
        
        public string Name { get; set; }
        public Gender Gender { get; set; }

        private DateTime _dob;
        public DateTime DOB
        {
            get { return _dob; }
            set { _dob = value; }
        }
    }
}