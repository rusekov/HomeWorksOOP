namespace EventPublishing
{
    using System;

    // Class that subscribes to an event 
    public class Subscriber
    {
        private string id;

        public Subscriber(string iD, Publisher pub)
        {
            this.id = iD;

            // Subscribe to the event using C# 2.0 syntax
            pub.RaiseCustomEvent += this.HandleCustomEvent;
        }

        // Define what actions to take when the event is raised. 
        public void HandleCustomEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine(this.id + " received this message: {0}", e.Message);
        }
    }
}
