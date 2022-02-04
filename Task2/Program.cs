using System;
using Task2;
using System.Collections;
using System.Collections.Generic;


var generator = new MapGenerator(new MapGeneratorOptions()
{
    Height = 35,
    Width = 90,
});



string[,] map = generator.Generate();
new MapPrinter().Print(map);





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



