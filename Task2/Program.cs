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





List<Point> GetNeighbours(int row, int column, string[,] maze)
{
    var result = new List<Point>();
    TryAddWithOffset(1, 0);
    TryAddWithOffset(-1, 0);
    TryAddWithOffset(0, 1);
    TryAddWithOffset(0, -1);
    return result;

    void TryAddWithOffset(int offsetRow, int offsetColumn)
    {
        var newX = row + offsetRow;
        var newY = column + offsetColumn;
        if (newX >= 0 && newY >= 0 && newX < maze.GetLength(0) 
            && newY < maze.GetLength(1) && maze[newX, newY] != "#")
        {
            result.Add(new Point(newY, newX));
        }
    }
}



