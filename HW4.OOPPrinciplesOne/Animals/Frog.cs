namespace Animals
{
    public class Frog : Animal
    {
        private const string AnimalIs = "Frog";        
        
        public Frog(string name, int age, Sex gender)
            : base(name, age, gender)
        {
        }

        public override string AnimalType
        {
            get { return AnimalIs; }
        }

        public override void MakeSound()
        {
            System.Console.WriteLine("{0} the frog said croak-croak", this.Name);
        }
    }
}
