//// Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students 
//// by first name and last name in descending order. 
//// Rewrite the same with LINQ.

namespace StudentsSort
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
                new { name = "Ivan", sirname = "Kanev" },
                new { name = "Ivan", sirname = "Rachkov" },
                new { name = "Ivan", sirname = "Vasilev" },
                new { name = "Stoyan", sirname = "Neykov" },
                new { name = "Nikola", sirname = "Ryadkov" },
            };

            //// Lambda sosrting by DESCENDING
            Console.WriteLine("\nDESCENDING LAMBDA EXPRESSION SORT: (FIRST NAME FIRST)\n");
            
            var lambdaSortedStudents = students.OrderByDescending(student => student.name).ThenByDescending(student => student.sirname);

            foreach (var student in lambdaSortedStudents)
            {
                Console.WriteLine("{0} {1}", student.name, student.sirname);
            }

            //// first we sort the students by sirname DESCENDING, and then we sort the SORTED students by first name DESCENDING
            //// as a result we have students sorted first by first name and if equal then by sirname , both DESCENDING            
            Console.WriteLine("\nDESCENDING LINQ SORT: (FIRST NAME FIRST)\n");
            
            var linqSortedStudents =
                from student in students
                orderby student.sirname descending                
                orderby student.name descending
                select student;

            foreach (var student in linqSortedStudents)
            {
                Console.WriteLine("{0} {1}", student.name, student.sirname);
            }
        }
    }
}