namespace SixtyFourBitArray
{
    using System;

    public class TestMain
    {
        public static void Main()
        {
            BitArray64 trueORFalse = new BitArray64();
            Random rand = new Random();
            for (int i = 0; i < 63; i++)
            {
                bool isTrue = new bool();
                if (rand.Next(2) == 1)
                {
                    isTrue = true;
                }

                trueORFalse[i] = isTrue ? 1 : 0;
            }

            for (int i = 0; i < 63; i++)
            {
                Console.Write(trueORFalse[i]);
            }

            Console.WriteLine();
        }
    }
}
