namespace Student
{
    using System;

    public class StudentTestingMain
    {
        public static void Main()
        {
            Student vankata = new Student("Ivan", "Ivanov", "Ivanov", "123456789", "Grad Sofia", "0888123456", 3, UniversityEnum.UNSS, FacultyEnum.Law, SpecialtyEnum.PublicLaw);

            Student cloningOfVankata = (Student)vankata.Clone();
            
            Student bugCloningOfVankata = new Student("Ivan", "Ivanov", "Ivanov", "123456798", "Grad Sofia", "0888123456", 3, UniversityEnum.UNSS, FacultyEnum.Law, SpecialtyEnum.PublicLaw);

            Console.WriteLine(vankata.ToString());
            Console.WriteLine(vankata.GetHashCode());
            Console.WriteLine(vankata.Equals(cloningOfVankata)); // return true
            Console.WriteLine(vankata == bugCloningOfVankata);   // return false
            Console.WriteLine(vankata != cloningOfVankata);      // return false
            Console.WriteLine(vankata.CompareTo(bugCloningOfVankata)); // returns -1
        }
    }
}
