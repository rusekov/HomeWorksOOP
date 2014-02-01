//// 1.
//// Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. 
//// Implement the ToString() to enable printing a 3D point.
//// 2.
//// Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. 
//// Add a static property to return the point O.

namespace The3DSpace
{
    using System;

    public struct Point
    {
        public static readonly Point ZeroCoordinates = new Point(0, 0, 0);

        public Point(int x, int y, int z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
 
        public int X { get; private set; }
        
        public int Y { get; private set; }

        public int Z { get; private set; } 

        public override string ToString()
        {
            string output = string.Format("Point coordinates {{X, Y, Z}} : {{{0}, {1}, {2}}}", this.X, this.Y, this.Z);
            return output;
        }
    }
}