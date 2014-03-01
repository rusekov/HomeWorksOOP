namespace Persons
{
    using System;

    public class TestingPersons
    {
        public static void Main(string[] args)
        {
            Person personWithAge = new Person("Unufri", 12);
            Person personWithoutAge = new Person("Ani");

            Console.WriteLine(personWithAge.ToString());
            Console.WriteLine(personWithoutAge.ToString());
        }
    }
}
