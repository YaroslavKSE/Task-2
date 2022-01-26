using Task2;
using System;
using System.Collections.Generic;


var generator = new MapGenerator(new MapGeneratorOptions()
{
    Height = 35,
    Width = 90,
});



string[,] map = generator.Generate();
new MapPrinter().Print(map);
var graph = map;

// List<Point> GetShortestPath(string[,] map, Point start, Point goal)
// {
//      your code here
// }


void SearchBFS(Point point)
{
    var visited = new List<Point>();
    var queue = new Queue<Point>();
    queue.Enqueue(point);
    while (queue.Count > 0)
    {
        var next = queue.Dequeue();
        var neighbours = 

    }



    void Visit(Point point)
    {
        graph[point.Row, point.Column] = "1";
        visited.Add(point);
    }
}


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
        var newRow = row + offsetRow;
        var newColumn = row + offsetColumn;
        if (newRow >= 0 && newColumn >= 0 && newRow < maze.GetLength(0)
            && newColumn < maze.GetLength(1) && maze[newRow, newColumn] != )

    }
}





