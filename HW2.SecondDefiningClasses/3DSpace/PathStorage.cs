//// Create a static class PathStorage with static methods to save and load paths from a text file. 
//// Use a file format of your choice.

namespace The3DSpace
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public static class PathStorage
    {
        private const string Filepath = @"..\..\savepath.txt";
        
        internal static void Save(Path path)
        {
            using (StreamWriter savePath = new StreamWriter(Filepath))
            {
                foreach (var poin in path.ListOfPoints)
                {
                    savePath.WriteLine(poin.X);
                    savePath.WriteLine(poin.Y);
                    savePath.WriteLine(poin.Z);
                }
            }
        }

        internal static void Load(Path path)
        {
            using (StreamReader loadPath = new StreamReader(Filepath))
            {                
                string pointX = loadPath.ReadLine();
                string pointY = loadPath.ReadLine();
                string pointZ = loadPath.ReadLine();
                
                if (pointX == null)
                {
                    Console.WriteLine("Empty record");   
                }
                else
                {
                    path.ListOfPoints.Clear();
                }

                while (pointX != null)
                {
                    Point point = new Point(int.Parse(pointX), int.Parse(pointY), int.Parse(pointZ));
                    pointX = loadPath.ReadLine();
                    pointY = loadPath.ReadLine();
                    pointZ = loadPath.ReadLine();
                    path.AddPoint(point);
                }
            }
        }
    }
}
