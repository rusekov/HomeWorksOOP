namespace MoreStudents
{    
    public class Group
    {
        public Group(int groupNr, string department)
        {
            this.GroupNumber = groupNr;
            this.DepartmentName = department;
        }

        public int GroupNumber { get; set; }

        public string DepartmentName { get; set; }
    }
}
