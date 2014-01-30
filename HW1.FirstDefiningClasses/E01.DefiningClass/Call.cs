namespace DefineGSM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Call
    {
        private DateTime dateTime;
        private int callDuration;

        public Call(DateTime datetime, string phonenumber, int callduration)
        {
            this.PhoneNumber = phonenumber;
            this.CallDuratiin = callduration;
            this.DateAndTime = datetime;
        }

        public string PhoneNumber { get; private set; }

        public int CallDuratiin
        {
            get { return this.callDuration; }
            private set { this.callDuration = value; }
        }

        public DateTime DateAndTime
        {
            get { return this.dateTime; }
            private set { this.dateTime = value; }
        }
    }
}