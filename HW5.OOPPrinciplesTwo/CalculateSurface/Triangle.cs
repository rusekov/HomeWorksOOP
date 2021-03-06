﻿namespace CalculateSurface
{
    public class Triangle : Shape
    {
        public Triangle(decimal height, decimal width)
            : base(height, width)
        {
        }

        public override decimal CalculateSurface()
        {
            return this.Width * this.Height / 2;
        }
    }
}
