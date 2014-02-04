//// Write a method that from a given array of students finds all students whose 
//// first name is before its last name alphabetically. Use LINQ query operators.
namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StudentsMain
    {    
        public static void Main()
        {
            var students = new[]
            {
                new { name = "Peter", sirname = "Mamalev" },
                new { name = "Stefan", sirname = "Paskalev" },
                new { name = "Georgi", sirname = "Kanev" },
                new { name = "Ivan", sirname = "Rachkov" },
                new { name = "Dimitar", sirname = "Vasilev" },
                new { name = "Stoyan", sirname = "Neykov" },
                new { name = "Nikola", sirname = "Ryadkov" },
            };

            var selectedStudents =
                from student in students
                where student.name[0] < student.sirname[0]
                select student;

            foreach (var student in selectedStudents)
            {
                Console.WriteLine("{0} {1}", student.name, student.sirname);
            }
        }
    }
}