using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GSM
{

    private string model;
    private string manifacturer;
    private decimal? price;
    private string owner;

    private Battery batt;
    private Display display;


    // e tuk ima veselba
    private List<Call> callHistory = new List<Call>();
    public List<Call> CallHistory
    {
        get { return this.callHistory; }
        private set { this.callHistory = value; }
    }


    // static iPhone
    internal static GSM iPhone4S = new GSM("iPhone4s","Apple",1000,"Mtel",
        new Battery(BatteryModel.LiPo2400), new Display(3.7,"16.5M"));

    public GSM (string model, string manifacturer) : this (model,manifacturer,null,null,null,null){}

    public GSM(string model, string manifacturer, decimal? price, string owner, Battery batteryModel, Display displayModel)
    {
        this.model = model;
        this.manifacturer = manifacturer;
        this.price = price;
        this.owner = owner;

        this.batt = batteryModel;
        this.display = displayModel;
    }

    public override string ToString()
    {
        return String.Format
        ("\nGSM: {0} \nManifacturer: {1} \nDisplay: {2} \nBattery: {3} \nBattery parameters: {4} \nPrice: {5} \nOwner: {6}", 
        this.model, this.manifacturer, this.display.Model, this.batt.Model,this.batt.BattertyData, this.price ,this.owner); 
    }

    public GSM IPhone4S 
    {
        get { return iPhone4S; } 
    }

    public void DeleteCallAtPositionFromHistory(int position)
    {
        this.callHistory.RemoveAt(position);
    }

    public void DeleteLastCallHistory()
    {
        this.callHistory.RemoveAt(callHistory.Count - 1);
    }

    public void ClearCallHistory()
    {
        this.callHistory.Clear();
    }

    public void AddCallToHistory(Call call)
    {
        this.callHistory.Add(call);
    }

    public void PrintCallHistory()
    {
        int index = 1;
        foreach (Call call in this.CallHistory)
        {
            Console.WriteLine("\nCall: {0}\nOn Date: {1} \nTo: {2} \nDuration (sec):{3}\n",index++,call.DateAndTime,call.phoneNumber,call.CallDuratiin);
        }
    }

    public decimal CurrentBill(decimal pricePerMinute)
    {
        decimal sum = new decimal();
        foreach (Call call in this.callHistory)
        {
            sum += call.CallDuratiin * pricePerMinute;
        }
        return sum;
    }


}

class GSMtest
{
    static GSM[] phoneCollection = new GSM[]
    {
        new GSM("Samsung Galaxy", "Samsung", 900,"Globul",new Battery(BatteryModel.LiPo2400),new Display(4.7,"16.5M")),
        new GSM("LG Optima", "LG", 909,"Globul",new Battery(BatteryModel.LIB1800),new Display(4,"16.5M")),
        new GSM("Sony Experis", "Sony", 800,"Globul",new Battery(BatteryModel.LIB1800),new Display(4,"16.5M")),
        new GSM("","").IPhone4S
    };

    public static void TestGSM()
    {
        foreach (GSM smartphone in phoneCollection)
        {
            Console.WriteLine(smartphone.ToString());
        }
        Console.WriteLine(GSM.iPhone4S);
    }
}

class GSMCallHistoryTest
{
    public static void TestFunctionality()
    {
        GSM Nokia1102 = new GSM("Nokia 5210", "Nokia", 29 , "Mtel", new Battery(BatteryModel.NiCd550), new Display(2, "2"));

        Nokia1102.AddCallToHistory(new Call(DateTime.Now, "mom", 90));        
        Nokia1102.AddCallToHistory(new Call(DateTime.Now, "mom", 99));
        Nokia1102.AddCallToHistory(new Call(DateTime.Today, "mom", 7));
        Nokia1102.AddCallToHistory(new Call(DateTime.Today, "mom", 40));

        Nokia1102.PrintCallHistory();

        Console.WriteLine(Nokia1102.CurrentBill(0.37M));

        int longestCall = int.MinValue;
        int longestCallIndex = new int();
        for (int i = 0; i < Nokia1102.CallHistory.Count; i++)
        {
            if (Nokia1102.CallHistory[i].CallDuratiin > longestCall)
            {
                longestCall = Nokia1102.CallHistory[i].CallDuratiin;
                longestCallIndex = i;
            }
        }

        Nokia1102.DeleteCallAtPositionFromHistory(longestCallIndex);

        Console.WriteLine(Nokia1102.CurrentBill(0.37M));

        Nokia1102.ClearCallHistory();
        Nokia1102.PrintCallHistory();
    }
}