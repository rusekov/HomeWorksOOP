namespace School
{
    using System;
    using System.Text.RegularExpressions;

    public abstract class People : IComentable
    {
        private string name;
    
        public People(string name)
        {
            this.Name = name;
        } 
        
        public string Name
        {            
            get
            {
                return this.name;
            }
            
            private set
            {
                if (!Regex.IsMatch(value, @"\b[A-Za-z][A-Za-z.-][A-Za-z.-]+\b"))
                {
                    throw new ArgumentException("The name must contain at least 3 symbols and could contain only latin letters, dashes and dots.");
                }

                this.name = value;
            }
        }

        public string Comment { get; set; }
    }
}
