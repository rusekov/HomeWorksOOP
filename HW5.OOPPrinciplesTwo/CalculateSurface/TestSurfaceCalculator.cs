namespace CalculateSurface
{
    public class TestSurfaceCalculator
    {
        public static void Main()
        {
            Shape[] shapes = new Shape[] 
            {
                new Circle(5),
                new Rectangle(5, 5),
                new Triangle(5, 5),
                new Circle(10),
                new Rectangle(10, 5),
                new Triangle(10, 5),
                new Circle(2),
                new Rectangle(1, 1),
                new Triangle(1, 1)
            };

            foreach (var shape in shapes)
            {
                System.Console.WriteLine(shape.CalculateSurface());
            }
        }
    }
}
