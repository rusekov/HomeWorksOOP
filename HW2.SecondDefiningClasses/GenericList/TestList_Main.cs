//// 7. Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the  GenericList<T>. 
//// You may need to add a generic constraints for the type T.

namespace GenericList
{
    using System;

    internal class TestList_Main
    {
        public static T Max<T>(T[] array)
           where T : IComparable
        {
            T result = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(array[i - 1]) > 0)
                {
                    result = array[i];
                }
            }

            return result;
        }

        public static T Min<T>(T[] array)
           where T : IComparable
        {
            T result = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(array[i - 1]) < 0)
                {
                    result = array[i];
                }
            }

            return result;
        }

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
            int minValue = Min(somelist.AsArray);
            int maxValue = Max(somelist.AsArray);

            Console.WriteLine("MinValue = {0}\nMaxValue = {1}\n", minValue, maxValue);

            ////Clear list - Nothing is printed
            somelist.Clear();
            for (int i = 0; i < somelist.Count; i++)
            {
                Console.WriteLine(somelist[i]);
            }
        }
    }
}
