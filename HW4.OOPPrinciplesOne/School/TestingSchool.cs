namespace School
{
    using System;

    public class TestingSchool
    {
        public static void Main()
        {
            Students jon = new Students("Jon");
            jon.Comment = "something";
            Console.WriteLine(jon.UniqueClassNr);
            
            Students mike = new Students("Mike");
            Console.WriteLine(mike.UniqueClassNr);
            
            Disciplines math = new Disciplines("Mathematics", 4, 2);
            math.Comment = "something";

            ////number of lectures and exercises should be changeble
            math.NumberOfLectures++;
            Console.WriteLine(math.NumberOfLectures);

            Disciplines english = new Disciplines("English", 4, 8);

            Teachers jonWu = new Teachers("Jon Wu");
            jonWu.Comment = "very clever man";
            jonWu.AddDiscipline(math);
            Teachers nutProfesor = new Teachers("Crazy Prof.", english, math);

            Classes alfa = new Classes("alfa");
            Classes beta = new Classes("beta", jonWu, nutProfesor);
            Classes omega = new Classes("omega", jon);
            alfa.AddTeacher(nutProfesor);
            alfa.AddStudent(jon);
        }    
    }
}