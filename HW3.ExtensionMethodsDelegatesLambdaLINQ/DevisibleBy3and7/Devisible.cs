//// Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
//// Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

//// Please pay attention thet the tast is to find the numbers devisible by 7 and 3, not by 7 or 3. 
//// otherwise you could replace && with ||

namespace DevisibleBy3and7
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Devisible
    {
        public static void Main()
        {
            int[] arrayOfNumbers = new int[] { 2, 3, 4, 5, 6, 7, 89, 9, 21, 28, 42, 49, 50, 84, 101 };

            //// using lambda
            Console.WriteLine("All numbers divisable to 3 and 7 using Lambda: ");
            var divisibleLambda = arrayOfNumbers.Where(number => number % 3 == 0 && number % 7 == 0);

            foreach (var number in divisibleLambda)
            {
                Console.WriteLine(number);
            }

            //// using Linq
            Console.WriteLine("All numbers divisable to 3 and 7 using Linq: ");
            var divisableLinq =
                from number in arrayOfNumbers
                where number % 3 == 0 && number % 7 == 0
                select number;

            foreach (var number in divisableLinq)
            {
                Console.WriteLine(number);
            }
        }
    }
}