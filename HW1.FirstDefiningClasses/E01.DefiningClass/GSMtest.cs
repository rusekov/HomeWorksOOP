namespace DefineGSM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class GSMtest
    {
        private static GSM[] phoneCollection = new GSM[] // is it private?
        {
            new GSM("Samsung Galaxy", "Samsung", 900, "Globul", new Battery(BatteryModel.LiPo2400), new Display(4.7, "16.5M")),
            new GSM("LG Optima", "LG", 909, "Globul", new Battery(BatteryModel.LIB1800), new Display(4, "16.5M")),
            new GSM("Sony Experis", "Sony", 800, "Globul", new Battery(BatteryModel.NiM1000), new Display(4, "16.5M")),
            GSM.IPhone4S
        };

        public static void TestGSM()
        {
            foreach (GSM smartphone in phoneCollection)
            {
                Console.WriteLine(smartphone.ToString());
            }

            Console.WriteLine(GSM.IPhone4S);
        }
    }
}
