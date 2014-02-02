namespace Version
{
    using System;
    using System.Runtime.InteropServices;

    [Version(1, 11)]
    public class Sample_Main
    {
        public static void Main()  
        {
            Type type = typeof(Sample_Main);
            dynamic[] allAttributes = type.GetCustomAttributes(false);
            
            foreach (VersionAttribute attribute in allAttributes)
            {
                Console.WriteLine("Version: {0}", attribute.Version);
            }
        }
    }
}