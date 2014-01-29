using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

    class Display
    {
        private double? size;
        private string numberOFColours;
        public Display()
        {
        }

        public Display(double? size, string colors)
        {
            this.Size = size;
            this.Colors = colors;
        }

        public double? Size
        {
            get { return this.Size; }
            private set 
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException("Display cannot be bigger than 10 and smaller than 1 inch");
                }

                this.size = value;
            }
        }
        public string Colors
        {
            get { return this.numberOFColours; }
            private set
            {
                bool valid = Regex.IsMatch(value, @"^\d+[a-z]*", RegexOptions.IgnoreCase);
                if (valid)
                {
                    this.numberOFColours = value;
                }
                else
                {
                    throw new ArgumentException(String.Format("Phone display can not have {0} coulours", value));
                }
            }
        }
               
        public string Model
        {
            get 
            {
                return String.Format("{0} inches, {1} colors", this.size, this.numberOFColours);
            }
        }

    }
