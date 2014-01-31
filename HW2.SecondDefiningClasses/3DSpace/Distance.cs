//// 3. Write a static class with a static method to calculate the distance between two points in the 3D space.

namespace The3DSpace
{
    using System;

    internal static class Distance
    {        
        public static double Calculate(Point pointA, Point pointB)
        {
            int deltaX = pointA.X - pointB.X;
            int deltaY = pointA.Y - pointB.Y;
            int deltaZ = pointA.Z - pointB.Z;
            return Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY) + (deltaZ * deltaZ));
        }
    }
}
