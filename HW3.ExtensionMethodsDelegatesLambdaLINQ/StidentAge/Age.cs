//// Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

namespace StidentAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Age
    {
        public static void Main()
        {
            var students = new[]
            {
                new { name = "Peter", sirname = "Mamalev", age = 17 },
                new { name = "Stefan", sirname = "Paskalev", age = 18 },
                new { name = "Georgi", sirname = "Kanev", age = 19 },
                new { name = "Ivan", sirname = "Rachkov", age = 27 },
                new { name = "Dimitar", sirname = "Vasilev", age = 25 },
                new { name = "Stoyan", sirname = "Neykov", age = 24 },
                new { name = "Nikola", sirname = "Ryadkov", age = 21 },
            };

            var selectedStudents =
                from student in students
                where (student.age >= 18 && student.age <= 24)
                select student;

            foreach (var student in selectedStudents)
            {
                Console.WriteLine("{0} {1} {2}", student.name, student.sirname, student.age);
            }
        }
    }
}