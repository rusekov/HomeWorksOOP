namespace GenericList
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Shelf<T> : IEnumerable<T>
        //where T : IITems
    {
        private const int DefaultCapacity = 20;

        private T[] array;
        private int index = 0;

        public Shelf()
            : this(DefaultCapacity)
        {
        }

        public int Count
        {
            get { return this.index; }
        }

        public T this[int i] // this is how to make indexing
        {
            get
            {
                if (i < 0 || i >= this.index)
                {
                    throw new IndexOutOfRangeException(string.Format("Index {0} out of range!", i));
                }

                T result = this.array[i];
                return result;
            }
        }

        public T Max()
        {
            T result = this.array[0];
            for (int i = 1; i < this.array.Length; i++)
            {
                if (this.array[i].CompareTo(this.array[i - 1]) > 0)
                {
                    result = this.array[i];
                }
            }

            return result;
        }

        public T Min()
        {
            T result = this.array[0];
            for (int i = 1; i < this.array.Length; i++)
            {
                if (this.array[i].CompareTo(this.array[i - 1]) < 0)
                {
                    result = this.array[i];
                }
            }

            return result;
        }

        public void Add(T element)
        {
            if (this.index < this.array.Length)
            {
                this.array[this.index] = element;
                this.index++;
            }
            else
            {
                this.AutoGrow();
                this.array[this.index] = element;
                this.index++;
            }
        }

        public void RemoveAt(int possition) //// there could be faster way
        {
            for (int i = possition; i < this.index; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            //// this.array[index] = ?? how to delete a T-object
            this.index--;
        }

        public void InsertAt(T element, int position) //// there could be faster way
        {
            this.index++;
            for (int i = this.index; i > position; i--)
            {
                this.array[i] = this.array[i - 1];
            }

            this.array[position] = element;
        }

        public void Clear()
        {
            this.index = 0;
            this.array = new T[DefaultCapacity];
            //// ? should I remove the elements and how
        }

        public bool Contains(T element)
        {
            bool result = false;
            for (int i = 0; i <= this.index; i++)
            {
                if (this.array[i].Equals(element))
                {
                    result = true;
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.index; i++)
            {
                result.Append(string.Format("Element {0}: {1}\n", i, this.array[i].ToString()));
            }

            return result.ToString();
        }

        private void AutoGrow()
        {
            T[] arr = new T[this.array.Length];
            for (int i = 0; i < this.array.Length; i++)
            {
                arr[i] = this.array[i];
            }

            this.array = new T[arr.Length * 2];
            for (int i = 0; i < arr.Length; i++)
            {
                this.array[i] = arr[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}