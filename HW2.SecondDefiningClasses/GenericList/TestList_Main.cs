namespace GenericList
{
    using System;

    internal class TestList_Main
    {
        internal static void Main()
        {
            //// adding element + AutoGrow()
            TList<int> somelist = new TList<int>(2);
            somelist.Add(1);
            somelist.Add(2);
            somelist.Add(3);

            //// removing element by index
            somelist.RemoveAt(1);

            //// inserting element at given position
            somelist.InsertAt(0, 0);

            //// accessing element by index (I feel so sleepy that I dont't see 2) 
            for (int i = 0; i < somelist.Count; i++)
            {
                Console.WriteLine(somelist[i]);
            }

            //// finding element by its value
            Console.WriteLine(somelist.Contains(3));

            ////ToString override
            Console.WriteLine(somelist.ToString());

            //// Min and max value
            int minValue = somelist.Min();
            int maxValue = somelist.Max();

            Console.WriteLine("MinValue = {0}\nMaxValue = {1}\n", minValue, maxValue);

            ////Clear list - List is empty & nothing is printed
            somelist.Clear();
            for (int i = 0; i < somelist.Count; i++)
            {
                Console.WriteLine(somelist[i]);
            }
        }
    }
}
