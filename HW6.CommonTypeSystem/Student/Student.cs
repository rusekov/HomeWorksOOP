namespace Student
{
    using System;
    using System.Text.RegularExpressions;

    public class Student : ICloneable, IComparable
    {        
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string permanentAddress;
        private string mobilePhone;
        private int course;

        public Student(
            string firstName,
            string middleName,
            string lastName,
            string ssn,
            string permanentAddress,
            string mobilePhone,
            int course,
            UniversityEnum university,
            FacultyEnum faculty,
            SpecialtyEnum specialty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Course = course;
            this.University = university;
            this.Faculty = faculty;
            this.Specialty = specialty;
        }

        public UniversityEnum University { get; set; }

        public FacultyEnum Faculty { get; set; }
        
        public SpecialtyEnum Specialty { get; set; }

        public int Course
        {
            get
            {
                return this.course;
            }

            set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Course must be number between 1 and 5");
                }

                this.course = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return (string)this.mobilePhone.Clone();
            }

            set
            {
                if (!Regex.IsMatch(value, @"\b[0][8][7-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]\b"))
                {
                    throw new ArgumentException("Mobile Phone must be 10 digits long and must start with 087, 088 or 089");
                }

                this.mobilePhone = value;
            }
        }

        public string PermanentAddress
        {
            get
            {
                return (string)this.permanentAddress.Clone();
            }

            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentException("Permanent address must be at least 5 symbols long");
                }

                this.permanentAddress = value;
            }
        }

        public string SSN
        {
            get
            {
                return (string)this.ssn.Clone();
            }

            private set
            {
                if (!Regex.IsMatch(value, @"\b[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]\b"))
                {
                    throw new ArgumentException("Social Security Number must contain 9 digits");
                }

                this.ssn = value;
            }
        }

        public string FirstName
        {
            get
            {
                return (string)this.firstName.Clone();
            }

            private set
            {
                this.NameCheck(value);
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return (string)this.middleName.Clone();
            }

            private set
            {
                this.NameCheck(value);
                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return (string)this.lastName.Clone();
            }

            private set
            {
                this.NameCheck(value);
                this.lastName = value;
            }
        }

        public static bool operator ==(Student student1, Student student2)
        {
            return student1.Equals(student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !student1.Equals(student2);
        }

        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            return this.firstName == student.FirstName &&
                this.middleName == student.MiddleName &&
                this.lastName == student.LastName &&
                this.ssn == student.SSN &&
                this.permanentAddress == student.PermanentAddress &&
                this.mobilePhone == student.MobilePhone &&
                this.course == student.Course &&                
                this.University.Equals(student.University) &&
                this.Faculty.Equals(student.Faculty) &&
                this.Specialty.Equals(student.Specialty);
        }

        public override int GetHashCode()
        {
            return int.Parse(this.SSN);
        }

        public override string ToString()
        {
            return string.Format(
                "\nName: {0} {1} {2}\nSSN# {3}\nAddress: {4}\nMobile# {5}\nCourse: {6}\nUniversity: {7}\nFaculty: {8}\nSpecialty: {9}\n",
                this.firstName,
                this.middleName,
                this.lastName,
                this.ssn,
                this.permanentAddress,
                this.mobilePhone,
                this.course,
                this.University,
                this.Faculty,
                this.Specialty);
        }

        public object Clone()
        {         
            return new Student(
                (string)this.firstName.Clone(),
                (string)this.middleName.Clone(),
                (string)this.lastName.Clone(),
                (string)this.ssn.Clone(),
                (string)this.permanentAddress.Clone(),
                (string)this.mobilePhone.Clone(),
                this.course,
                this.University,
                this.Faculty,
                this.Specialty);
        }

        public int CompareTo(object student)
        {                 
            int firstNameResult = string.Compare(
                this.firstName, 
                (student as Student).firstName, 
                StringComparison.Ordinal);

            if (firstNameResult == 0)
            {
                int middleNameResult = string.Compare(
                    this.middleName, 
                    (student as Student).middleName, 
                    StringComparison.Ordinal);

                if (middleNameResult == 0)
                {
                    int lastNameResult = string.Compare(
                        this.lastName,
                        (student as Student).lastName,
                        StringComparison.Ordinal);

                    if (lastNameResult == 0)
                    {
                        return (int)this.ssn.CompareTo((student as Student).ssn);
                    }

                    return lastNameResult;
                }

                return middleNameResult;
            }

            return firstNameResult;
        }

        private void NameCheck(string name)
        {
            if (!Regex.IsMatch(name, @"\b[A-Za-z][A-Za-z][A-Za-z]+\b"))
            {
                throw new ArgumentException("Name must contain at least 3 symbols and latin letters only", name);
            }
        }
    }
}