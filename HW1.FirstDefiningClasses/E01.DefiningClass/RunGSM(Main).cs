namespace DefineGSM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class RunGsm
    {
        internal static void Main()
        {
            // tests
            string iphone = "iPhone";
            string apple = "Apple";
            string ivan = "Ivan";

            Battery panasonic = new Battery(BatteryModel.LiPo2400);
            Display samsung = new Display(7, "16M");

            GSM gsm = new GSM(iphone, apple, 10, ivan, panasonic, samsung);
            Console.WriteLine(gsm.ToString());
            
            GSM promo = new GSM("Nokia 1010", "Nokia");
            Console.WriteLine(promo.ToString());

            GSM itelfon = GSM.IPhone4S;
            Console.WriteLine(itelfon.ToString());

            object newitelfon = GSM.IPhone4S;

            GSMtest.TestGSM();

            Call somecall = new Call(DateTime.Now, "+33 35 53444", 59);

            GSMCallHistoryTest.TestFunctionality();
        }
    }
}