namespace Animals
{
    public class Cat : Animal
    {
        private const string AnimalIs = "Cat";

        public Cat(string name, int age, Sex gender)
            : base(name, age, gender)
        {
        }

        public override string AnimalType
        {
            get { return this.GetType().Name; }
        }
                
        public override void MakeSound()
        {
            if (this.Gender == Sex.Female)
            {
                System.Console.WriteLine("{0} the kitten said meow, meow, meow...", this.Name);
            }
            else
            {
                System.Console.WriteLine("{0} the tomcat said mrrrrrr...", this.Name);
            }
        }
    }
}
