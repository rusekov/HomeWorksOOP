namespace School
{
    using System;
    using System.Collections.Generic;

    public class Classes : IComentable
    {
        private static List<string> forbiddenID = new List<string>();
        
        private string uniqueTextId;
        private List<Teachers> setOfTeachers;
        private List<Students> setOfStudents;

        public Classes(string classId)
        {
            this.setOfTeachers = new List<Teachers>();
            this.setOfStudents = new List<Students>();
            this.TextId = classId;
        }
        
        public Classes(string classId, params Teachers[] teachers)
            : this(classId)
        {
            foreach (var teacher in teachers)
            {
                this.setOfTeachers.Add(teacher);
            }
        }

        public Classes(string classId, params Students[] students)
            : this(classId)
        {
            foreach (var student in students)
            {
                this.setOfStudents.Add(student);
            }
        }
        
        public List<Teachers> SetOfTeachers 
        {
            get { return new List<Teachers>(this.setOfTeachers); }
        }

        public List<Students> SetOfStudents
        {
            get { return new List<Students>(this.setOfStudents); }
        }

        public string TextId
        {
            get 
            { 
                return this.uniqueTextId; 
            }

            set 
            {
                foreach (var id in forbiddenID)
                {
                    if (value == id)
                    {
                        throw new ArgumentException("The Class ID must be unique");
                    }
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("The Class ID must be at least 3 symbols long");
                }

                this.uniqueTextId = value;
                forbiddenID.Add(value);
            }
        }

        public string Comment { get; set; }
     
        public void AddTeacher(Teachers teacher)
        {
            this.setOfTeachers.Add(teacher);
        }

        public void RemoveTeacher(Teachers teacher)
        {
            this.setOfTeachers.Remove(teacher);
        }

        public void AddStudent(Students student)
        {
            this.setOfStudents.Add(student);
        }

        public void RemoveStudetn(Students student)
        {
            this.setOfStudents.Add(student);
        }
    }
}
