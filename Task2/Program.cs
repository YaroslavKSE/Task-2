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
var graph = new string[,]
{
    { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
    { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
    { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
    { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
    { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
    { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
    { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
    { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
    { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
    { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
    { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
    { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
};

Print(graph);
SearchBFS(new Point(14, 5));


double Heuristic(Point a, Point b)
{
    return Math.Abs(a.Row - b.Row) + Math.Abs(a.Column - b.Column);
}

List<Point> GetShortestPath(string[,] map, Point start, Point goal)
{
    var frontier = new Queue();
    frontier.Enqueue(goal);
    
    Dictionary<Point, Point> cameFrom  = new Dictionary<Point, Point>();
    Dictionary<Point, double> costSoFar  = new Dictionary<Point, double>();
    
    cameFrom[start] = start;
    costSoFar[start] = 0;

    while (frontier.Count > 0)
    {
        var current = frontier.Dequeue();
        if (current.Equals(start)) 
        
        {
            break;
        }
        
    }
        
    return null;
        
}



void SearchBFS(Point point)
{
    var visited = new List<Point>();
    var queue = new Queue<Point>();
    Visit(point);
    queue.Enqueue(point);
    while (queue.Count > 0)
    {
        var next = queue.Dequeue();
        Print(graph);
        var neighbours = GetNeighbours(next.Row, next.Column, graph);
        foreach (var neighbour in neighbours)
        {
            if (!visited.Contains(neighbour))
            {
                Visit(neighbour);
                queue.Enqueue(neighbour);
            }
        }
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
        var newX = row + offsetRow;
        var newY = column + offsetColumn;
        if (newX >= 0 && newY >= 0 && newX < maze.GetLength(0) 
            && newY < maze.GetLength(1) && maze[newX, newY] != "#")
        {
            result.Add(new Point(newY, newX));
        }
    }
}

void Print(string[,] array)
{
    for (var row = 0; row < array.GetLength(0); row++)
    {
        for (var column = 0; column < array.GetLength(1); column++)
        {
            Console.Write(array[row, column]);
        }

        Console.WriteLine();
    }
    Console.WriteLine();
}


public interface WeightedGraph<P>
{
    double Cost(Point a, Point b);
    IEnumerable<Point> Neighbors(Point id);
}

public class SquareGrid : WeightedGraph<Point>
{
    public static readonly Point[] DIRS = new[]
    {
        new Point(1, 0),
        new Point(0, -1),
        new Point(-1, 0),
        new Point(0, 1)
    };

    public int width, height;
    private HashSet<Point> walls = new HashSet<Point>();
    private HashSet<Point> forests = new HashSet<Point>();
    private WeightedGraph<Point> _weightedGraphImplementation;

    public SquareGrid(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public bool InBounds(Point id)
    {
        return 0 <= id.Row && id.Row < width
                           && 0 <= id.Column && id.Column < height;
    }

    public bool Passable(Point id)
    {
        return !walls.Contains(id);
    }

    public double Cost(Point a, Point b)
    {
        return forests.Contains(b) ? 5 : 1;
    }

    public IEnumerable<Point> Neighbors(Point id)
    {
        foreach (var dir in DIRS)
        {
            Point next = new Point(id.Row + dir.Row, id.Column + dir.Column);
            if (InBounds(next) && Passable(next))
            {
                yield return next;
            }
        }
    }
}


