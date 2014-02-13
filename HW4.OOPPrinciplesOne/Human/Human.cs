namespace Human
{
    using System;
    using System.Text.RegularExpressions;
 
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get 
            { 
                return this.firstName; 
            }

            private set 
            {
                if (!Regex.IsMatch(value, @"\b[A-Za-z][A-Za-z][A-Za-z]+\b"))
                {
                    throw new ArgumentException("First name must contain at least 3 symbols and could contain only latin letters");
                }
 
                this.firstName = value; 
            }
        }

        public string LastName
        {
            get 
            { 
                return this.lastName; 
            }

            private set 
            {
                if (!Regex.IsMatch(value, @"\b[A-Za-z][A-Za-z][A-Za-z]+\b"))
                {
                    throw new ArgumentException("Last name must contain at least 3 symbols and could contain only latin letters");
                }

                this.lastName = value; 
            }
        } 
    }
}
