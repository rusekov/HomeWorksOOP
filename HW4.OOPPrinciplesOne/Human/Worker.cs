namespace Human
{
    using System;

    public class Worker : Human
    {
        private decimal weekSalary;
        private int workHoursPerWeek;

        public Worker(string name, string sirname, int weeklySalary, int workHoursPerWeek)
            : base(name, sirname)
        {
            this.WeekSalary = weeklySalary;
            this.WorkHoursPerWeek = workHoursPerWeek;
        }

        public int WorkHoursPerWeek
        {
            get 
            { 
                return this.workHoursPerWeek; 
            }
            
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Worker cant have negative hours");
                }
                else if (value > 65)
                {
                    throw new ArgumentOutOfRangeException("It is not allowed to work more than 65 hours!");
                }
                else if (value < 1 && this.weekSalary > 0)
                {
                    throw new ArgumentOutOfRangeException("Worker is paid only for the working hours");
                }

                this.workHoursPerWeek = value; 
            }
        }
        
        public decimal WeekSalary
        {
            get 
            { 
                return this.weekSalary; 
            }
            
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Worker can not have negative salary");
                }

                this.weekSalary = value; 
            }
        }
        
        public decimal MoneyPerHour()
        {
            return Math.Round(this.WeekSalary / this.workHoursPerWeek, 2);
        }

        public override string ToString()
        {
            return string.Format("Worker {0} {1}, Week Salary {2}$ for {3}h at {4}$/hour", this.FirstName, this.LastName, this.WeekSalary, this.WorkHoursPerWeek, this.MoneyPerHour());
        }
    }
}
