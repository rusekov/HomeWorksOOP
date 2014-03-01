namespace CalculateSurface
{
    using System;

    public abstract class Shape
    {
        private decimal height;
        private decimal width;

        public Shape(decimal height, decimal width)
        {
            this.Height = height;
            this.Width = width;
        }

        protected decimal Height
        {
            get 
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Size must be positive");
                }

                this.height = value;
            }
        }

        protected decimal Width 
        {
            get 
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Size must be positive");
                }

                this.width = value;
            }
        }       

        public abstract decimal CalculateSurface();
    }
}
