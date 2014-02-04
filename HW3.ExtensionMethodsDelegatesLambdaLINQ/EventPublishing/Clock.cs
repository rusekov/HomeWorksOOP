namespace EventPublishing
{
using System;
using System.Threading;
    
    public class Clock
    {
        private const int SecondConst = 0;
        private int sleep;

        public Clock(int sleep)
        {
            this.sleep = sleep;
        }

        public event TimeChangedEventHandler ChangeTime;

        public int Sleep
        {
            get
            {
                return this.sleep;
            }
        }

        public int Seconds
        {
            get
            {
                return SecondConst;
            }
        }

        public void Run()
        {
            int seconds = this.Seconds;

            Thread newThread = new Thread(() =>
            {
                Console.WriteLine("Press ESC to stop");
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        Thread.Sleep(this.sleep * 1000);
                        seconds += this.sleep;
                        Change(seconds);
                    }
                }
                while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            });

            newThread.Start();
        }

        protected void Change(int seconds)
        {
            if (this.ChangeTime != null)
            {
                this.ChangeTime(this, new Event(seconds));
            }
        }               
    }
}
