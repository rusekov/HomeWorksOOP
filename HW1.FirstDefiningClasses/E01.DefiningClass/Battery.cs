namespace DefineGSM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum BatteryModel
    {
        NiM1000 = 1000, NiCd550 = 550, LIB1800 = 1800, LiPo2400 = 2400
    }

    internal class Battery
    {
        private BatteryModel batteryModel = BatteryModel.NiM1000;
        private decimal hoursIddle = 200M;
        private decimal hoursTalk = 4M;

        public Battery(BatteryModel batteryModel)
        {
            this.batteryModel = batteryModel;
            this.hoursIddle = (decimal)this.batteryModel / 5;
            this.hoursTalk = (decimal)this.batteryModel / 250;
        }

        public Battery()
        {
        }

        public BatteryModel Model
        {
            get 
            { 
                return this.batteryModel; 
            }
        }

        public decimal HoursIddle
        {
            get 
            { 
                return this.hoursIddle; 
            }
        }

        public decimal HoursTalk
        {
            get 
            { 
                return this.hoursTalk; 
            }
        }

        public string BattertyData
        {
            get 
            { 
                return string.Format("Max {0}h iddle; max {1}h talk", this.hoursIddle, this.hoursTalk); 
            }
        }
    }
}