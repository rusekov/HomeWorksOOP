namespace The3DSpace
{
    using System;
    using System.Collections.Generic;

    internal class Pathfinder
    {                
        public static void Main()
        {
            Point firstPoint = new Point(1, 2, 3);
            Console.WriteLine(firstPoint.ToString());

            Point secondPoint = new Point(2, 6, 8);
            Console.WriteLine(secondPoint.ToString());

            Point zeroPoint = Point.ZeroCoordinates;
            Console.WriteLine(zeroPoint.ToString());

            double distanceFirstSecond = Distance.Calculate(firstPoint, secondPoint);
            Console.WriteLine(distanceFirstSecond);

            Path somePath = new Path(firstPoint, secondPoint, zeroPoint, new Point(12, 12, 12));
            somePath.AddPoint(zeroPoint);
            somePath.AddPoint(firstPoint);
            somePath.AddPoint(secondPoint);

            var listOfPoints = somePath.ListOfPoints;

            foreach (Point point in listOfPoints)
            {
                Console.WriteLine(point.ToString());
            }

            somePath.ShowPath();

            PathStorage.Save(somePath);

            Path reloadPath = new Path();
            PathStorage.Load(reloadPath);

            reloadPath.ShowPath();
        }
    }
}
