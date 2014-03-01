// I cant find the solution here

namespace BinarySearch
{
    using System;

    public class TestMain
    {
        public static void Main()
        {
            TreeNod test = new TreeNod(10);
            test.Add(3);
            test.Add(5);
            test.Add(4);
            test.Add(6);
            test.Add(7);
            test.Add(14);

            Console.WriteLine(test.Contains(10));
            Console.WriteLine(test.Contains(3));
            Console.WriteLine(test.Contains(5));
            Console.WriteLine(test.Contains(8));
        }
    }
}
