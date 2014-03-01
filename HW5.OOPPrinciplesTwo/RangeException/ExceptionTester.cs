namespace RangeException
{
    using System;
    using System.Globalization;

    public class ExceptionTester
    {
        private const int MinNumber = 1;
        private const int MaxNumber = 100;
        private const string EarliestDate = "1980.01.01";
        private const string LatestDate = "2013.12.31";
        
        public static void Main()
        {
            Console.Write("Enter Number: ");
            int inputNumber = int.Parse(Console.ReadLine());

            if (inputNumber < 1 || inputNumber > 100)
            {
                throw new InvalidRangeException<int>("Value is outside the range", 1, 100);
            }

            Console.Write("Enter date in 'dd.MM.yyyy' format: ");
            DateTime inputDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            DateTime lowerbound = DateTime.ParseExact(EarliestDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            DateTime higherbound = DateTime.ParseExact(LatestDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            if (inputDate < lowerbound || inputDate > higherbound)
            {
                throw new InvalidRangeException<DateTime>("Value is outside the range", lowerbound, higherbound);
            }
        }
    }
}