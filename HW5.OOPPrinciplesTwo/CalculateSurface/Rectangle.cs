namespace CalculateSurface
{
    public class Rectangle : Shape
    {
        public Rectangle(decimal height, decimal width)
            : base(height, width)
        {
        }

        public override decimal CalculateSurface()
        {
            return this.Width * this.Height;
        }
    }
}
