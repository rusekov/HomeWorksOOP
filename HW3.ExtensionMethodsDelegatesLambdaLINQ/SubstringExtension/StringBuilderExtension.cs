//// Implement an extension method Substring(int index, int length) for the class StringBuilder that 
//// returns new StringBuilder and has the same functionality as Substring in the class String.

namespace SubstringExtension
{
    using System;
    using System.Text;

    public static class StringBuilderExtension
    {
        public static StringBuilder SubString(this StringBuilder someStringBuilder, int startIndex)
        {
            return new StringBuilder(someStringBuilder.ToString().Substring(startIndex));
        }

        public static StringBuilder SubString(this StringBuilder someStringBuilder, int startIndex, int length)
        {
            return new StringBuilder(someStringBuilder.ToString().Substring(startIndex, length));
        }
    }
}