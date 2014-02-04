namespace EventPublishing
{
    using System;

    public class Event : EventArgs
    {
        public Event(int seconds)
        {
            this.Seconds = seconds;
        }

        public int Seconds { get; set; }
    }
}