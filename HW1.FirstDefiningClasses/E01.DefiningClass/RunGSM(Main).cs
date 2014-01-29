using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        //string iPhone = "iPhone";
        //string apple = "Apple";
        //string ivan = "Ivan";
        
        Battery panasonic = new Battery(BatteryModel.LiPo2400);
        Display samsung = new Display(7, "16M");

        //GSM gsm = new GSM(iPhone, apple, 10, ivan, panasonic, samsung);
        ////GSM promo = new GSM("Nokia 1010", "Nokia"); // tva ne raboti

        //Console.WriteLine(gsm.ToString());
        object itelfon = GSM.iPhone4S;

        Console.WriteLine(itelfon.ToString());
        //Console.WriteLine(promo.ToString());

        //GSMtest.TestGSM();

        Call somecall = new Call(DateTime.Now, "+333553444", 59);

        GSMCallHistoryTest.TestFunctionality();
    }
}