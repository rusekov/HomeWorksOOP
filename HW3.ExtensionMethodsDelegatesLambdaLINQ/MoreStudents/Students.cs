namespace MoreStudents
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Students
    {        
        public Group GroupName { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public int FN { get; set; }
        
        public string Tel { get; set; }
        
        public string Email { get; set; }
        
        public List<int> Marks { get; set; }
        
        public int GroupNumber 
        {
            get 
            {
                return this.GroupName.GroupNumber;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "\nFaculty Nr.: {0}\nFirst Name: {1}\nLast Name: {2}\nEmail: {3}\nTel: {4}\nGroup Nr.: {5}\nMarks: {6}\n", 
                this.FN, 
                this.FirstName, 
                this.LastName, 
                this.Email, 
                this.Tel, 
                this.GroupNumber,
                string.Join(",", this.Marks));
        }
    }
}
