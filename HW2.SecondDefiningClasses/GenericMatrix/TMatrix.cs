//// 8. Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 

//// 9. Implement an indexer this[row, col] to access the inner matrix cells.

//// 10. Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication. 
//// Throw an exception when the operation cannot be performed. ?Implement the true operator (check for non-zero elements).? 

namespace GenericMatrix
{
    using System;
    using System.Text;

    public class TMatrix<T>
        where T : struct                                        //// anythig else here???
    {
        private const int DefaultRows = 8;
        private const int DefaultCols = 8;

        private int rows;
        private int cols;
        private T[,] matrix;

        public TMatrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.matrix = new T[this.rows, this.cols];
        }

        public TMatrix()
            : this(DefaultRows, DefaultCols)
        {
        }

        public int Rows
        {
            get 
            { 
                return this.rows; 
            }
            
            private set
            {
                if (value > 0)
                {
                    this.rows = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Matrix could have only positive dimentions");
                }
            }
        }

        public int Cols
        {
            get 
            { 
                return this.cols; 
            }

            private set
            {
                if (value > 0)
                {
                    this.cols = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Matrix could have only positive dimentions");
                }
            }
        }

        // create indexing
        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= this.rows || col < 0 || col >= this.cols)
                {
                    throw new IndexOutOfRangeException(string.Format("Index [{0},{1}] out of range!", row, col));
                }

                T result = this.matrix[row, col];
                return result;
            }

            set
            {
                if (row < 0 || row >= this.rows || col < 0 || col >= this.cols)
                {
                    throw new IndexOutOfRangeException(string.Format("Index [{0},{1}] out of range!", row, col));
                }

                this.matrix[row, col] = value;
            }
        }

        public static TMatrix<T> operator +(TMatrix<T> m1, TMatrix<T> m2)
        {
            if (m1.Cols == m2.Cols && m1.Rows == m2.Rows)
            {
                TMatrix<T> result = new TMatrix<T>();

                for (int row = 0; row < m1.Rows; row++)
                {
                    for (int col = 0; col < m1.Cols; col++)
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
                throw new ArithmeticException("The matrices should be the same size to apply \"+\" operator");
            }
        }

        public static TMatrix<T> operator -(TMatrix<T> m1, TMatrix<T> m2)
        {
            if (m1.Cols == m2.Cols && m1.Rows == m2.Rows)
            {
                TMatrix<T> result = new TMatrix<T>();

                for (int row = 0; row < m1.Rows; row++)
                {
                    for (int col = 0; col < m1.Cols; col++)
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
                throw new ArithmeticException("The matrices should be the same size to apply \"-\" operator");
            }
        }

        /* For Matrix multiplication see: 
         * http://www.mathsisfun.com/algebra/matrix-multiplying.html
         * http://en.wikipedia.org/wiki/Matrix_multiplication
         */

        public static TMatrix<T> operator *(TMatrix<T> m1, TMatrix<T> m2)
        {
            if (m1.Cols == m2.Rows)
            {
                dynamic result = new TMatrix<T>();

                for (int m1row = 0; m1row < m1.Rows; m1row++)
                {
                    for (int m2col = 0; m2col < m2.Cols; m2col++)
                    {
                        for (int mem = 0; mem < m1.Cols; mem++)
                        {
                            dynamic a = m1[m1row, mem];
                            dynamic b = m2[mem, m2col];

                            result[m1row, m2col] += a * b;
                        }                        
                    }
                }

                return result;
            }
            else
            {
                throw new ArithmeticException("The matrices are not multipliable. Matrix1.Cols should be equal to Matrix2.Rows");
            }           
        }  

        public static bool operator false(TMatrix<T> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if ((dynamic)matrix[row, col] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator true(TMatrix<T> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if ((dynamic)matrix[row, col] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
