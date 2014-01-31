//// 4. 
//// Create a class Path to hold a sequence of points in the 3D space. 
//// Create a static class PathStorage ->  << go to PathStorage.cs for more >>

namespace The3DSpace
{
    using System;
    using System.Collections.Generic;

    internal class Path
    {
        private List<Point> listOfPoints;

        public Path()
        {
            this.listOfPoints = new List<Point>();
        }

        public List<Point> ListOfPoints
        {
            get { return new List<Point>(this.listOfPoints); }
        }

        public void AddPoint(Point point)
        {
            this.listOfPoints.Add(point);
        }

        ////this is an extra method to print the path
        public void ShowPath()
        {
            Console.WriteLine("\nThe path goes through point:");

            foreach (Point point in this.listOfPoints)
            {
                Console.WriteLine(point.ToString());
            }

            Console.WriteLine("End.");
        }
    }
}
