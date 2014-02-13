namespace Human
{
    using System;

    public class Student : Human
    {
        private int grade;

        public Student(string name, string sirname, int grade)
            : base(name, sirname)
        {
            this.Grade = grade;
        }
        
        public int Grade 
        { 
            get
            {
                return this.grade;
            }

            set
            {
                if (value < 1 || value > 13)
                {
                    throw new ArgumentOutOfRangeException("Grade should be between 1 and 13 inclusive");
                }

                this.grade = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Student {0} {1} at {2} grade", this.FirstName, this.LastName, this.Grade);
        }
    }
}
