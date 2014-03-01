namespace RangeException
{
    public class InvalidRangeException<T> : System.ApplicationException
    {
        public InvalidRangeException()
            : base()
        {
        }

        public InvalidRangeException(string msg, T start, T end)
            : base(msg + string.Format(" [{0}, {1}]", start, end))
        {
            this.Start = start;
            this.End = end;
        }

        public T Start { get; private set; }

        public T End { get; private set; }
    }
}
