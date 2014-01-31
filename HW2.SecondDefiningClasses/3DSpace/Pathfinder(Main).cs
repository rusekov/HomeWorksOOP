﻿namespace The3DSpace
{
    using System;
    using System.Collections.Generic;

    internal class Pathfinder
    {                
        public static void Main(string[] args)
        {
            Point firstPoint = new Point(1, 2, 3);
            Console.WriteLine(firstPoint.ToString());

            Point secondPoint = new Point(2, 6, 8);
            Console.WriteLine(secondPoint.ToString());

            Point zeroPoint = Point.ZeroCoordinates;
            Console.WriteLine(zeroPoint.ToString());

            double distanceFirstSecond = Distance.Calculate(firstPoint, secondPoint);
            Console.WriteLine(distanceFirstSecond);

            Path somePath = new Path();
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

            //// Testing ListOfPoints class

            Console.WriteLine("\nListOfPoints is equal to List<Point> (just another way to implement Path):");
            ListOfPoints testPath = new ListOfPoints();
            testPath.Add(zeroPoint);
            testPath.Add(secondPoint);

            foreach (var item in testPath)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}