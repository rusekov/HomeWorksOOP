namespace School
{
    using System;
    using System.Text.RegularExpressions;

    public class Disciplines : IComentable
    {
        private string name;
        
        public Disciplines (string name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfExercises = numberOfExercises;
            this.NumberOfLectures = numberOfLectures;
        }

        public int NumberOfLectures { get; set; }

        public int NumberOfExercises { get; set; }

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
