namespace Human
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TestingHuman
    {
        public static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student("Ivan", "Popov", 10),
                new Student("Ivan", "Ivanov", 6),
                new Student("Ivan", "Mishev", 5),
                new Student("Ivan", "Grigorov", 7),
                new Student("Petko", "Ivanov", 2),
                new Student("Mitko", "Ivanov", 3),
                new Student("Dancho", "Ivanov", 11),
                new Student("Vasil", "Ivanov", 10),
                new Student("Tochko", "Ninov", 12),
                new Student("Nino", "Tochkov", 4)
            };

            students.OrderBy(st => st.Grade);

            Console.WriteLine("\n<<< Studetns sorted by Grade>>>\n");
            students.ToList().ForEach(Console.WriteLine);

            var workers = new List<Worker>
            {
                new Worker("Nikola", "Popov", 140, 40),
                new Worker("Nikola", "Ivanov", 194, 50),
                new Worker("Nikola", "Mishev", 244, 30),
                new Worker("Nikola", "Grigorov", 114, 20),
                new Worker("Petko", "Popov", 440, 65),
                new Worker("Mitko", "Popov", 1900, 40),
                new Worker("Dancho", "Vanchev", 500, 64),
                new Worker("Vasil", "Lilov", 400, 60),
                new Worker("Tochko", "Ganev", 300, 40),
                new Worker("Nino", "Fospodinov", 300, 43)
            };

            workers.OrderByDescending(wo => wo.MoneyPerHour());
            
            Console.WriteLine("\n<<< Workers sorted by $/hour>>>\n");
            workers.ToList().ForEach(Console.WriteLine);

            List<Human> humans = new List<Human>();
            students.ForEach(humans.Add);
            workers.ForEach(humans.Add);

            var sortedListOfHumans = humans.OrderBy(hu => hu.FirstName).ThenBy(hu => hu.LastName);
            Console.WriteLine("\n<<< Humans sorted by first name and last name>>>\n");            
            sortedListOfHumans.ToList().ForEach(Console.WriteLine);
        }
    }
}
