namespace EventPublishing
{
    using System;
    
    // Define a class to hold custom event info 
    public class CustomEventArgs : EventArgs
    {
        private string message;
        
        public CustomEventArgs(string s)
        {
            this.message = s;
        } 

        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }
    }
}
