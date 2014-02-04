namespace IEnumExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class IEnumMain
    {
        public static void Main()
        {
            List<double> newlist = new List<double>() { 2, 3, 4, 5, 6, 7, 8, 9, 1, 12, 23, 44 };
            Console.WriteLine(newlist.Average());
            Console.WriteLine(newlist.Sum());
            Console.WriteLine(newlist.Product());
            Console.WriteLine(newlist.Min());
            Console.WriteLine(newlist.Max());
        }
    }
}