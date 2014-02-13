namespace EventPublishing
{
    using System;
    using System.Threading;

    // Class that publishes an event 
    public class Publisher
    {
        // Declare the event using EventHandler<T> 
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;

        public void PrintOnSecond(int seconds)
        {
            // Do something + Rise an event (order doesn't matter)
            Console.WriteLine("Press ESC to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    Thread.Sleep(seconds * 1000);
                    
                    // Rising the event
                    this.OnRaiseCustomEvent(new CustomEventArgs(string.Format("{0} seconds later", seconds)));
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);                               
        }

        // Wrap event invocations inside a protected virtual method to allow derived classes to override the event invocation behavior 
        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of a race condition if the last subscriber unsubscribes 
            // immediately after the null check and before the event is raised.
            EventHandler<CustomEventArgs> handler = this.RaiseCustomEvent;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                e.Message += string.Format(" at {0}", DateTime.Now.ToLongTimeString());

                // Use the () operator to raise the event.
                handler(this, e);
            }
        }
    }
}
