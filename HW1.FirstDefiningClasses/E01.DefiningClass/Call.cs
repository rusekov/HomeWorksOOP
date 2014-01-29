using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Call
{

    private DateTime dateTime;
    public string phoneNumber { get; private set; }
    private int callDuration;

    public Call(DateTime datetime, string phonenumber, int callduration)
    {
        this.phoneNumber = phonenumber;
        this.CallDuratiin = callduration;
        this.DateAndTime = datetime;
    }


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