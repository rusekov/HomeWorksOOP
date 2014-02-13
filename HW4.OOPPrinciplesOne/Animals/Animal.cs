namespace Animals
{
    using System;
    using System.Text.RegularExpressions;

    public abstract class Animal : ISound, ITypeOfAnimal
    {
        private string name;
        private int age;
        
        public Animal(string name, int age, Sex gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public abstract string AnimalType { get; }

        public Sex Gender { get; private set; }

        public int Age
        {
            get 
            { 
                return this.age; 
            }

            set 
            {
                if (value < 0 || value > 200)
                {
                    throw new ArgumentOutOfRangeException(string.Format("{0} years old animal can not be categorized in properly"));
                }

                this.age = value; 
            }
        }        

        public string Name
        {
            get 
            { 
                return this.name; 
            }
            
            private set 
            {
                if (!Regex.IsMatch(value, @"\b[A-Za-z][A-Za-z]+\b"))
                {
                    throw new ArgumentException("First name must contain at least 2 symbols and could contain only latin letters");
                }

                this.name = value; 
            }
        }        
        
        public virtual void MakeSound()
        {
            Console.WriteLine("Тhe animal made a quiet sound");
        }
    }
}
