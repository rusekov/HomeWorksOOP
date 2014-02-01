//// 8. Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 

//// 9. Implement an indexer this[row, col] to access the inner matrix cells.

//// 10. Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication. 
//// Throw an exception when the operation cannot be performed. ?Implement the true operator (check for non-zero elements).? 

namespace GenericMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TMatrix<T>
        where T : struct
    {
        private const int DefaultRows = 8;
        private const int DefaultCols = 8;

        private int maxRows;
        private int maxCols;

        private T[,] matrix;

        public TMatrix(int maxRows, int maxCols)
        {
            this.maxRows = maxRows;
            this.maxCols = maxCols;
            this.matrix = new T[this.maxRows, this.maxCols];
        }

        public TMatrix()
            : this(DefaultRows, DefaultCols)
        {
        }

        public int MaxRows
        {
            get { return this.maxRows; }
        }

        public int MaxCols
        {
            get { return this.maxCols; }
        }

        public T this[int row, int col] // this is how to make indexing
        {
            get
            {
                if (row < 0 || row >= this.maxRows || col < 0 || col >= this.maxCols)
                {
                    throw new IndexOutOfRangeException(string.Format("Index [{0},{1}] out of range!", row, col));
                }

                T result = this.matrix[row, col];
                return result;
            }

            set
            {
                this.matrix[row, col] = value;
            }
        }

        public static TMatrix<T> operator +(TMatrix<T> m1, TMatrix<T> m2)
        {
            if (m1.MaxCols == m2.MaxCols && m1.MaxRows == m2.MaxRows)
            {
                dynamic result = new TMatrix<T>(); // try dynamic... looks like hack

                for (int row = 0; row < m1.MaxRows; row++)
                {
                    for (int col = 0; col < m1.MaxCols; col++)
                    {
                        dynamic a = m1[row, col];
                        dynamic b = m2[row, col];

                        result[row, col] = a + b;
                    }
                }

                return result;
            }
            else
            {
                throw new ArithmeticException("The matrixes should be the same size to apply \"+\" operator");
            }
        }

        public static TMatrix<T> operator -(TMatrix<T> m1, TMatrix<T> m2)
        {
            if (m1.MaxCols == m2.MaxCols && m1.MaxRows == m2.MaxRows)
            {
                dynamic result = new TMatrix<T>(); // try dynamic... looks like hack

                for (int row = 0; row < m1.MaxRows; row++)
                {
                    for (int col = 0; col < m1.MaxCols; col++)
                    {
                        dynamic a = m1[row, col];
                        dynamic b = m2[row, col];

                        result[row, col] = a - b;
                    }
                }

                return result;
            }
            else
            {
                throw new ArithmeticException("The matrixes should be the same size to apply \"-\" operator");
            }
        }

        public static TMatrix<T> operator *(TMatrix<T> m1, TMatrix<T> m2)
        {
            if (m1.MaxCols == m2.MaxCols && m1.MaxRows == m2.MaxRows)
            {
                dynamic result = new TMatrix<T>(); // I dont know math!

                for (int row = 0; row < m1.MaxRows; row++)
                {
                    for (int col = 0; col < m1.MaxCols; col++)
                    {
                        dynamic a = m1[row, col];
                        dynamic b = m2[row, col];

                        result[row, col] = a * b;
                    }
                }

                return result;
            }
            else
            {
                throw new ArithmeticException("The matrixes should be the same size to apply \"+\" operator");
            }
        }  
    }
}
