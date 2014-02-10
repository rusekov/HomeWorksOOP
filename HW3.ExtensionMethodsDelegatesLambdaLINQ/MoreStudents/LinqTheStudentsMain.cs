namespace MoreStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LinqTheStudentsMain
    {
        public static void Main()
        {
            var mathGroup = new Group(2, "Mathematics");
            var informaticsGroup = new Group(1, "Informatics");
            var groups = new List<Group> { mathGroup, informaticsGroup };
                        
            var listOfStudents = new List<Students>
            {
                new Students 
                { 
                    FN = 121205101,
                    FirstName = "Gosho", 
                    LastName = "Petkov",
                    Tel = "+359 2 888 888",
                    Email = "Gosho@mail.bg",
                    GroupName = mathGroup,
                    Marks = new List<int> { 2, 3, 4, 5 }
                },
                new Students 
                { 
                    FN = 121206102,
                    FirstName = "Ani", 
                    LastName = "Zarkova",
                    Tel = "0888 888 777",
                    Email = "Anji@abv.bg",
                    GroupName = informaticsGroup,
                    Marks = new List<int> { 6, 6, 4, 5, 6 }
                },
                new Students 
                { 
                    FN = 121205103,
                    FirstName = "Zvezdi", 
                    LastName = "Antonov",
                    Tel = "0888 234 568",
                    Email = "zvezdata@abv.bg",
                    GroupName = mathGroup,
                    Marks = new List<int> { 2, 2, 2, 3, 4 }
                },
                new Students 
                { 
                    FN = 121204104,
                    FirstName = "Ani", 
                    LastName = "Petkova",
                    Tel = "02 887 887",
                    Email = "Ani89@abv.bg",
                    GroupName = mathGroup,
                    Marks = new List<int> { 2, 4 }
                },
                new Students 
                { 
                    FN = 121203105,
                    FirstName = "Margaritka", 
                    LastName = "Karamfilova",
                    Tel = "0889 999 888",
                    Email = "Cvete@mail.bg",
                    GroupName = informaticsGroup,
                    Marks = new List<int> { 4, 6 }
                },
                new Students 
                { 
                    FN = 121206106,
                    FirstName = "Gosho", 
                    LastName = "Antonov",
                    Tel = "056 28 1212",
                    Email = "GoshoMashinata@abv.bg",
                    GroupName = informaticsGroup,
                    Marks = new List<int> { 6, 6, 6, 5, 6 }
                }
            };

            //// Test: Printing all the students
            //listOfStudents.ForEach(Console.WriteLine);

            //// 9.Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.

            var sortedStudentFromGroupTwo =
                from student in listOfStudents
                where student.GroupNumber == 2
                orderby student.FirstName
                select student;
            
            //// Print:
            //sortedStudentFromGroupTwo.ToList<Students>().ForEach(Console.WriteLine);

            //// 10.Implement the previous using the same query expressed with extension methods.

            var sortedStudentsFromGroupTwoAgain = listOfStudents
                .Where(st => st.GroupNumber == 2)
                .OrderBy(st => st.FirstName);

            //// Print:
            // sortedStudentsFromGroupTwoAgain.ToList<Students>().ForEach(Console.WriteLine);

            //// 11.Extract all students that have email in abv.bg. Use string methods and LINQ.

            var abvBgSubscribers = listOfStudents.Where(st => st.Email.Contains("@abv.bg"));

            //// Print:
            // abvBgSubscribers.ToList<Students>().ForEach(Console.WriteLine);

            //// 12.Extract all students with phones in Sofia. Use LINQ.

            var containsPhoneInSofia = listOfStudents.Where(st => 
                st.Tel.StartsWith("02") || 
                st.Tel.StartsWith("00359 2") || 
                st.Tel.StartsWith("+359 2"));

            //// Print:
            // containsPhoneInSofia.ToList<Students>().ForEach(Console.WriteLine);

            //// 13.Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.

            var exelentStudent =
                from student in listOfStudents
                where student.Marks.Contains(6)
                select new { Fullname = student.FirstName + " " + student.LastName, Marks = string.Join(",", student.Marks) };

            //// Print: (Marks are represented as string in order to appear here)         
            // exelentStudent.ToList().ForEach(Console.WriteLine);

            //// 14.Write down a similar program that extracts the students with exactly  two marks "2". Use extension methods.

            var studentsWithTwoMarks = listOfStudents
                .Where(st => st.Marks.Count == 2)
                .Select(st => new { Name = st.FirstName + " " + st.LastName, Marks = string.Join(",", st.Marks) });

            //// Print: (Marks are represented as string in order to appear here)         
            // studentsWithTwoMarks.ToList().ForEach(Console.WriteLine);

            //// 15. Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).

            string marksOfStudentsOlSix = string.Join(
                ",", 
                listOfStudents
                .Where(st => st.FN
                    .ToString()
                    .Substring(4, 2)
                    .Equals("06"))
                .Select(st => string.Join(",", st.Marks)));

            ////Print:
            //Console.WriteLine(marksOfStudentsOlSix);

            //// 16.* Create a class Group with properties GroupNumber and DepartmentName. 
            //// Introduce a property Group in the Student class. 
            //// Extract all students from "Mathematics" department. Use the Join operator.

            var matematicians =
                from study in groups
                where study.DepartmentName == "Mathematics"
                join student in listOfStudents on study.GroupNumber equals student.GroupNumber
                select new { study.DepartmentName, student };
            
            ////Print:
            //matematicians.ToList().ForEach(Console.WriteLine);
            
            //// 18. Create a program that extracts all students grouped by GroupName and then prints them to the console.  Use LINQ.

            //// 19. Rewrite the previous using extension methods.


        }
    }
}