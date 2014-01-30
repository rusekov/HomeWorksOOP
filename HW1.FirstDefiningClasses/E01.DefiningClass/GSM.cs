namespace DefineGSM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    internal class GSM
    {
        //// static iPhone
        ////private static GSM iphone4S; 
    
        private string model;
        private string manifacturer;
        private decimal? price;
        private string owner;

        private Battery batt;
        private Display display;

        //// e tuk ima veselba 
        private List<Call> callHistory;

        public GSM(string model, string manifacturer) : this(model, manifacturer, null, null, null, null)
        {
        }

        public GSM(string model, string manifacturer, decimal? price, string owner, Battery batteryModel, Display displayModel)
        {
            this.Model = model;
            this.Manifacturer = manifacturer;
            this.Price = price;
            this.Owner = owner;
            this.callHistory = new List<Call>();

            this.batt = batteryModel;
            this.display = displayModel;
        }

        public static GSM IPhone4S
        {
            get { return new GSM("iPhone4s", "Apple", 1000, "Mtel", new Battery(BatteryModel.LiPo2400), new Display(3.7, "16.5M")); }
        }
    
        public List<Call> CallHistory
        {
            get { return this.callHistory; }
            private set { this.callHistory = value; }
        }

        public decimal? Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value == null)
                {
                    this.price = null;
                }
                else if (value < 0)
                {
                    throw new ArgumentException("There could not be negative price");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (value == null)
                {
                    this.model = null;
                }
                else
                {
                    bool valid = Regex.IsMatch(value, @"^[a-z1-9]+", RegexOptions.IgnoreCase);

                    if (valid)
                    {
                        this.model = value;
                    }
                    else
                    {
                        throw new ArgumentException("The phone model description could contain only latin chars and digits", value);
                    }
                }
            }
        }

        public string Manifacturer
        {
            get
            {
                return this.manifacturer;
            }

            private set
            {
                if (value == null)
                {
                    this.manifacturer = null;
                }
                else
                {
                    bool valid = Regex.IsMatch(value, @"^[a-z1-9]+", RegexOptions.IgnoreCase);

                    if (valid)
                    {
                        this.manifacturer = value;
                    }
                    else
                    {
                        throw new ArgumentException("The manifacturer description could contain only latin chars and digits", value);
                    }
                }
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            private set
            {
                if (value == null)
                {
                    this.owner = null;
                }
                else
                {
                    bool valid = Regex.IsMatch(value, @"^[a-z1-9]+", RegexOptions.IgnoreCase); // owner could be company like "Generic2013"

                    if (valid)
                    {
                        this.owner = value;
                    }
                    else
                    {
                        throw new ArgumentException("The owner description could contain only latin chars and digits", value);
                    }
                }
            }
        }

        public override string ToString()
        {
            if (this.price == null || this.owner == null || this.display.Model == null)
            {
                return string.Format("\nGSM: {0} \nManifacturer: {1}", this.model, this.manifacturer);
            }

            return string.Format("\nGSM: {0} \nManifacturer: {1} \nDisplay: {2} \nBattery: {3} \nBattery parameters: {4} \nPrice: {5} \nOwner: {6}", this.model, this.manifacturer, this.display.Model, this.batt.Model, this.batt.BattertyData, this.price, this.owner);
        }

        public void DeleteCallAtPositionFromHistory(int position)
        {
            this.callHistory.RemoveAt(position);
        }

        public void DeleteLastCallHistory()
        {
            this.callHistory.RemoveAt(this.callHistory.Count - 1);
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
                Console.WriteLine("\nCall: {0}\nOn Date: {1} \nTo: {2} \nDuration (sec):{3}\n", index++, call.DateAndTime, call.PhoneNumber, call.CallDuratiin);
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
}