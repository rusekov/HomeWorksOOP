namespace GenericMatrix
{
    using System;
    using System.Text;

    public class MatixTester_Main
    {
        private static void Main()
        {
            TMatrix<int> defoultArrayOfNumbers = new TMatrix<int>(); //// initiate default array 8,8
            TMatrix<int> arrayOfNumbers = new TMatrix<int>(8, 8); 
  
            for (int i = 0; i < arrayOfNumbers.Rows; i++)
            {
                for (int j = 0; j < arrayOfNumbers.Cols; j++)
                {
                    arrayOfNumbers[i, j] = (i + j) % 10;
                    Console.Write("{0} ", arrayOfNumbers[i, j]);
                }

                Console.Write("\t->\t");
                for (int j = 0; j < arrayOfNumbers.Cols; j++)
                {
                    defoultArrayOfNumbers[i, j] = (i + j) % 5;
                    Console.Write("{0} ", defoultArrayOfNumbers[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            TMatrix<int> sum = new TMatrix<int>();
            TMatrix<int> difference = new TMatrix<int>();
            TMatrix<int> product = new TMatrix<int>();

            sum = arrayOfNumbers + defoultArrayOfNumbers;
            difference = arrayOfNumbers - defoultArrayOfNumbers;
            product = arrayOfNumbers * defoultArrayOfNumbers;

            for (int row = 0; row < sum.Rows; row++)
            {
                Console.Write("(a+b)->  ");                
                for (int col = 0; col < sum.Cols; col++)
                {
                    Console.Write("{0,2} ", sum[row, col]);
                }
                
                Console.Write("  (a-b)->  ");                
                for (int col = 0; col < sum.Cols; col++)
                {
                    Console.Write("{0,1} ", difference[row, col]);
                }
                
                Console.Write("  (a*b)->  ");                
                for (int col = 0; col < sum.Cols; col++)
                {
                    Console.Write("{0,2} ", product[row, col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            // testing the bool operator for zero elements
            if (product)
            {
                Console.WriteLine("True Product");
            }
            else
            {
                Console.WriteLine("False Product");
            }

            if (sum)
            {
                Console.WriteLine("true Sum");
            }
            else
            {
                Console.WriteLine("False Sum");
            }
        }
    }
}
