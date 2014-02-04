namespace SubstringExtension
{
    using System;
    using System.Text;

    public class ExtensionMain
    {
        private static void Main()
        {
            StringBuilder someStringBuilder = new StringBuilder("Retrieves a substring from this instance. The substring starts at a specified character position and continues to the end of the string.");

            //// index
            Console.WriteLine(someStringBuilder.SubString(42));
            //// index ,length
            Console.WriteLine(someStringBuilder.SubString(0, 41));
        }
    }
}