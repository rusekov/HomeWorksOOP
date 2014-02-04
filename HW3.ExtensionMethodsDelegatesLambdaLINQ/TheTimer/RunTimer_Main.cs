//// Using delegates write a class Timer that has can execute certain method at each t seconds.

namespace TheTimer
{
    using System;
    using System.Linq;
    using System.Threading;

    public delegate void TimerDelegate(int seconds);

    public class RunTimer_Main
    {
        public static void PrintOnSecond(int seconds)
        {
           Console.WriteLine("Press ESC to stop");
           do 
           {
               while (!Console.KeyAvailable)
               {
                   Thread.Sleep(seconds * 1000);
                   Print(seconds);
               }       
            } 
           while (Console.ReadKey(true).Key != ConsoleKey.Escape);           
        }

        public static void Print(int seconds)
        {
            Console.WriteLine("Printed after {0}, seconds", seconds);                          
        }

        public static void Main()
        {
            TimerDelegate ticTac = new TimerDelegate(PrintOnSecond);
            ticTac(1);
        }
    }
}