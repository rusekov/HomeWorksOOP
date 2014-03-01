namespace SixtyFourBitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray64 : IEnumerable<int>, IEquatable<BitArray64>
    {
        private ulong number;

        public BitArray64()
        {
        }

        public int this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException("Index cannot be negative");
                }
                else if (index > 63)
                {
                    throw new IndexOutOfRangeException("Index cannot exceed 63");
                }

                return (int)(this.number >> index) & 1;
            }

            set
            {
                ulong mask = (ulong)1 << index;

                if (index < 0)
                {
                    throw new IndexOutOfRangeException("Index cannot be negative");
                }
                else if (index > 63)
                {
                    throw new IndexOutOfRangeException("Index cannot exceed 63");
                }

                if (value == 1)
                {
                    this.number = this.number | mask;
                }
                else if (value == 0)
                {
                    this.number = this.number & ~mask;
                }
                else
                {
                    throw new ArgumentException("Value must be 1 ot 0");
                }
            }
        }

        public static bool operator ==(BitArray64 our, BitArray64 other)
        {
            return our.Equals(other);
        }

        public static bool operator !=(BitArray64 our, BitArray64 other)
        {
            return !our.Equals(other);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Equals(BitArray64 other)
        {
            return this.number == other.number;
        }

        public override bool Equals(object obj)
        {
            return this.number == (obj as BitArray64).number;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.number.GetHashCode();
        }
    }
}