using System;
using Task2;
using System.Collections;
using System.Collections.Generic;


var globalHeight = 35;
var globalWidth = 90;
var generator = new MapGenerator(new MapGeneratorOptions()
{
      Height = globalHeight,
      Width = globalWidth,
});

string[,] map = generator.Generate();
var toStart = new Point(0, 0);
var finish = new Point(globalWidth - 2, globalHeight - 2);
List<Point> path = GetShortestPath(map, toStart, finish);
new MapPrinter().Print(map, path);


List<Point> GetShortestPath(string[,] map, Point start, Point goal)
            {
                var localPath = new List<Point> {start};
                var lastPoint = goal;
                var costSoFar = new Dictionary<Point, int>();
                var cameFrom = new Dictionary<Point, Point>();
                var frontier = new Queue<Point>();
                frontier.Enqueue(start);
                costSoFar.Add(start, 0);
    
                return localPath;
            }

List<Point> GetNeighbours(string[,] localMap2, Point current)
            {
                List<Point> available = new List<Point>();
                if (current.Column - 1 >= 0 && current.Column - 1 <= globalWidth - 1 && current.Row <= globalWidth - 1)
                {
                    if (localMap2[current.Column - 1, current.Row] != "█")
                    {
                        available.Add(new Point(current.Column - 1, current.Row));
                    }
                }

                if (current.Column + 1 >= 0 && current.Column + 1 <= globalWidth - 1 && current.Row <= globalWidth - 1)
                {
                    if (localMap2[current.Column + 1, current.Row] != "█")
                    {
                        available.Add(new Point(current.Column + 1, current.Row));
                    }
                }

                if (current.Row - 1 >= 0 && current.Row - 1 <= globalHeight - 1 && current.Column <= globalWidth - 1)
                {
                    if (localMap2[current.Column, current.Row - 1] != "█")
                    {
                        available.Add(new Point(current.Column, current.Row - 1));
                    }
                }

                if (current.Row + 1 >= 0 && current.Row + 1 <= globalHeight - 1 && current.Column <= globalWidth - 1)
                {
                    if (localMap2[current.Column, current.Row + 1] != "█")
                    {
                        available.Add(new Point(current.Column, current.Row + 1));
                    }
                }

                return available;
            }



