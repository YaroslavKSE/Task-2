using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
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
                while (frontier.Count != 0)
                {
                    var current = frontier.Dequeue();
                    var available = GetNeighbours(map, current);
                    foreach (var point in available)
                    {
                        if (!cameFrom.ContainsKey(point))
                        {
                            frontier.Enqueue(point);
                            cameFrom.Add(point, current);
                            if (!costSoFar.ContainsKey(point))
                            {
                                costSoFar.Add(point, costSoFar[current] + 1);
                            }
                        }
                        else if (cameFrom.ContainsKey(point) && costSoFar[current] + 1 < costSoFar[point])
                        {
                            cameFrom[point] = current;
                        }
                    }

                    if (current.Equals(goal))
                    {
                        lastPoint = goal;
                        break;
                    }
                }

                var lenOf = costSoFar[lastPoint];
                for (var i = 0; i != lenOf; i++)
                {
                    localPath.Add(cameFrom[lastPoint]);
                    lastPoint = cameFrom[lastPoint];
                }

                localPath.Add(goal);
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
        }
    }
}