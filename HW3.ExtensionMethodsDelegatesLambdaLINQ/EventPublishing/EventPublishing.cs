//// * Read in MSDN about the keyword event in C# and how to publish events. 
//// Re-implement the above (E07) using .NET events and following the best practices.

namespace EventPublishing
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            Publisher pub = new Publisher();
            Subscriber sub1 = new Subscriber("Somebody", pub);
            
            // Call the method that raises the event.
            pub.PrintOnSecond(1);
        }
    }
}