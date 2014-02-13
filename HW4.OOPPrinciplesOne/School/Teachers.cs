namespace School
{
    using System.Collections.Generic;

    public class Teachers : People
    {
        private List<Disciplines> setOfDisciplines;
        
        public Teachers(string name)
            : base(name)
        {
            this.setOfDisciplines = new List<Disciplines>();
        }
        
        public Teachers(string name, params Disciplines[] disciplines) 
            : this(name)
        {
            for (int i = 0; i < disciplines.Length; i++)
            {
                this.setOfDisciplines.Add(disciplines[i]);
            }
        }

        public List<Disciplines> SetOfDisciplines
        {
            get { return new List<Disciplines>(this.setOfDisciplines); }
        }

        public void AddDiscipline(Disciplines discipline)
        {
            this.setOfDisciplines.Add(discipline);
        }

        public void RemoveDiscipline(Disciplines discipline)
        {
            this.setOfDisciplines.Remove(discipline);
        }
    }
}
