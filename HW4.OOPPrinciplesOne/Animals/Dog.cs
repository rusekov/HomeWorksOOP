namespace Animals
{
    public class Dog : Animal
    {
        private const string AnimalIs = "Dog";

        public Dog(string name, int age, Sex gender)
            : base(name, age, gender)
        {
        }

        public override string AnimalType
        {
            get { return AnimalIs; }
        }

        public override void MakeSound()
        {
            System.Console.WriteLine("{0} the dog said woof", this.Name);
        }
    }
}
