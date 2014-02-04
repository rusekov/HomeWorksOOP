//// Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, 
//// product, min, max, average.
namespace IEnumExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class IEnumerableExtensions
    {        
        public static T Sum<T>(this IEnumerable<T> array)
                where T : struct, IComparable,
                        IComparable<T>,
                        IConvertible,
                        IEquatable<T>,
                        IFormattable
        {
            dynamic result = new T();
            foreach (var item in array)
            {
                result += item;
            }

            return result;
        }

        public static T Product<T>(this IEnumerable<T> array)
                where T : struct, IComparable,
                        IComparable<T>,
                        IConvertible,
                        IEquatable<T>,
                        IFormattable
        {
            dynamic result = (dynamic)1;
            foreach (var item in array)
            {
                result *= item;
            }

            return result;
        }

        public static T Average<T>(this IEnumerable<T> array)
                where T : struct, IComparable,
                        IComparable<T>,
                        IConvertible,
                        IEquatable<T>,
                        IFormattable
        {
            dynamic sum = new T();
            dynamic count = new T();
            foreach (var item in array)
            {
                sum += item;
                count++;
            }

            return sum / count;
        }

        public static T Max<T>(this IEnumerable<T> array)
                where T : struct, IComparable,
                        IComparable<T>,
                        IConvertible,
                        IEquatable<T>,
                        IFormattable
        {
            var list = new List<T>();
            
            foreach (var item in array)
            {
                list.Add(item);
            }
            
            T result = list[0];

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].CompareTo(result) > 0)
                {
                    result = list[i];
                }
            }
            
            return result;
        }

        public static T Min<T>(this IEnumerable<T> array)
                where T : struct, IComparable,
                        IComparable<T>,
                        IConvertible,
                        IEquatable<T>,
                        IFormattable
        {
            var list = new List<T>();
            
            foreach (var item in array)
            {
                list.Add(item);
            }
            
            T result = list[0];

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].CompareTo(result) < 0)
                {
                    result = list[i];
                }
            }
            
            return result;
        }
    }
}