namespace CalculateSurface
{
    using System;

    public class Circle : Shape
    {
        public Circle(decimal diameter)
            : base(diameter, diameter)
        {
        }

        public override decimal CalculateSurface()
        {
            return (this.Height / 2) * (this.Height / 2) * (decimal)Math.PI;
        }
    }
}
