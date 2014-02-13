namespace School
{
    public class Students : People
    {
        private const int FirstNumber = 20140001;
        
        private static int counter = FirstNumber;

        public Students(string name) : base(name)
        {
            this.UniqueClassNr = GetUniqueNumber();
        }

        public int UniqueClassNr { get; private set; }
 
        private static int GetUniqueNumber()
        {
            return counter++;
        }
    }
}
