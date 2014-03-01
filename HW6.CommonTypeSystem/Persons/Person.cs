namespace Persons
{
    using System;
    using System.Text.RegularExpressions;

    public class Person
    {
        private string name;
        private int? age;

        public Person(string name)
        {
            this.Name = name;
        }

        public Person(string name, int? age)
            : this(name)
        {
            this.Age = age;
        }

        public int? Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (this.age < 0)
                {
                    throw new ArgumentOutOfRangeException("Age must be positive integer number");
                }

                this.age = value;
            }
        }

        public string Name
        {
            get 
            { 
                return (string)this.name.Clone(); 
            }

            set
            {
                if (!Regex.IsMatch(value, @"\b[A-Za-z][A-Za-z][A-Za-z]+\b"))
                {
                    throw new ArgumentException("Name must contain at least 3 symbols and latin letters only", value);
                }

                this.name = value; 
            }
        }

        public override string ToString()
        {
            if (this.age == null)
            {
                return string.Format("Name: {0}, Age: [not specified]", this.name);
            }
            else
            {
                return string.Format("Name: {0}, Age: {1}", this.name, this.age);
            }
        }
    }
}
