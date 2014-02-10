////* Read in MSDN about the keyword event in C# and how to publish events. 
//// Re-implement the above using .NET events and following the best practices.

//// watch here!!! : http://www.youtube.com/watch?v=CPlMeTgAJXg 

namespace EventPublishing
{    
using System;
using System.Threading;

    public delegate void TimeChangedEventHandler(object sender, Event e);    

    public class Publish
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SingleEvent(object sender, Event e)
        {            
            Console.WriteLine("Printed after {0} seconds", e.Seconds);
        }

        public static void Main()
        {
            Clock someEvent = new Clock(2);
            someEvent.ChangeTime += SingleEvent;
            someEvent.Run();
        }
    }
}