namespace DefineGSM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class GSMCallHistoryTest
    {
        public static void TestFunctionality()
        {
            GSM nokia1102 = new GSM("Nokia 5210", "Nokia", 29, "Mtel", new Battery(BatteryModel.NiCd550), new Display(2, "2"));

            nokia1102.AddCallToHistory(new Call(DateTime.Now, "mom", 90));
            nokia1102.AddCallToHistory(new Call(DateTime.Now, "mom", 99));
            nokia1102.AddCallToHistory(new Call(DateTime.Today, "mom", 7));
            nokia1102.AddCallToHistory(new Call(DateTime.Today, "mom", 40));

            nokia1102.PrintCallHistory();

            Console.WriteLine(nokia1102.CurrentBill(0.37M));

            int longestCall = int.MinValue;
            int longestCallIndex = new int();

            for (int i = 0; i < nokia1102.CallHistory.Count; i++)
            {
                if (nokia1102.CallHistory[i].CallDuratiin > longestCall)
                {
                    longestCall = nokia1102.CallHistory[i].CallDuratiin;
                    longestCallIndex = i;
                }
            }

            nokia1102.DeleteCallAtPositionFromHistory(longestCallIndex);

            Console.WriteLine(nokia1102.CurrentBill(0.37M));

            nokia1102.ClearCallHistory();

            nokia1102.PrintCallHistory();
        }
    }
}
