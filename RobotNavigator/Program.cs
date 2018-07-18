using System;
using System.Collections.Generic;
using System.IO;

namespace RobotNavigator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to robot navigator!");

            int[] upperRightCoords = new int[2];
            var allLines = File.ReadAllLines("input.txt");
            var stringCoords = allLines[0].Split(new char[] { ' ' });
            upperRightCoords[0] = int.Parse(stringCoords[0]);
            upperRightCoords[1] = int.Parse(stringCoords[1]);

            var gridDimension = upperRightCoords[0] * upperRightCoords[1];

            var robots = new List<Robot>();

            for(int i = 1; i < allLines.Length - 1; i += 2) {
                var x = int.Parse(allLines[i].Split(new char[] { ' ' })[0]);
                var y = int.Parse(allLines[i].Split(new char[] { ' ' })[1]);
                var direction = allLines[i].Split(new char[] { ' ' })[2];
                robots.Add(new Robot(new Position(x, y, direction), allLines[i+1]));
            }
            var grid = new List<Coordinate>();
            for (int i = 0; i <= upperRightCoords[0]; i++) {
                for (int j = 0; j <= upperRightCoords[0]; j++)
                {
                    grid.Add(new Coordinate(i, j));
                }
            }

            robots.ForEach(r => {
                Console.WriteLine($"Robot starting Facing {r.GetInfo()}");
                r.Move(grid);
                Console.WriteLine($"final position {r.GetInfo()}");
            });
        }
    }
}
