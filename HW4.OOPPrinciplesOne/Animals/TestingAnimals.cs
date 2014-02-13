namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TestingAnimals
    {
        public static void Main()
        {
            List<Animal> zoopark = new List<Animal>()
            {
                new Tomcat("Tom", 5),
                new Kitten("Kate", 4),
                new Cat("Leo", 9, Sex.Male),
                new Cat("Missy", 2, Sex.Female),
                new Dog("Jango", 18, Sex.Male),
                new Dog("Gosho", 8, Sex.Male),
                new Dog("Lasi", 10, Sex.Female),
                new Frog("Kermit", 5, Sex.Male),
                new Frog("Prince", 1, Sex.Male)
            };

            // Sound test:
            foreach (var animal in zoopark)
            {
                animal.MakeSound();
            }
            
            Console.WriteLine("\n<<<< Average ages by animals >>>>\n");

            var averageAges = zoopark.GroupBy(type => type.AnimalType);

            foreach (var pair in averageAges)
            {
                Console.WriteLine("{0}s' average age is {1} years", pair.Key, pair.Average(an => an.Age));
            }
        }
    }
}
