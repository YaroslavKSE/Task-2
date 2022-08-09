using DijkstraSearch;

const int globalHeight = 50;
const int globalWidth = 70;

var options = new MapGeneratorOptions
{
    Height = globalHeight,
    Width = globalWidth,
    Seed = 77
    // Noise = (float) 0.3;
};

var maze = new MapGenerator(options).Generate();

var startPoint = new Point(0, 0);
var endPoint = new Point(globalWidth - 2, globalHeight - 2);
maze[startPoint.Column, startPoint.Row] = "A";
maze[endPoint.Column, endPoint.Row] = "B";
var path = new List<Point>
{
    startPoint,
    endPoint
};


List<Point> GetShortestPath(string[,] map, Point start, Point goal)
{
    var frontier = new PriorityQueue<Point, int>();
    frontier.Enqueue(start, 0);
    var distances = new Dictionary<Point, int>();
    var origins = new Dictionary<Point, Point>
    {
        [start] = start
    };
    distances[start] = 0;
    while (frontier.Count != 0)
    {
        var current = frontier.Dequeue();
        if (current.Equals(goal)) break;

        foreach (var nextPoint in Neighbours(map, current))
        {
            var costOfMovements = distances[current] + CostOfMovement(current, nextPoint);
            if (!distances.ContainsKey(nextPoint) || costOfMovements < distances[nextPoint])
            {
                distances[nextPoint] = costOfMovements;
                var priority = costOfMovements;
                frontier.Enqueue(nextPoint, priority);
                origins[nextPoint] = current;
            }
        }
    }

    var secondCurrent = goal;
    var paths = new List<Point>();
    while (!secondCurrent.Equals(start))
    {
        paths.Add(secondCurrent);
        secondCurrent = origins[secondCurrent];
    }

    paths.Reverse();
    return paths;
}

var result = GetShortestPath(maze, startPoint, endPoint);
foreach (var variable in result) path.Add(variable);

List<Point> Neighbours(string[,] map, Point point)
{
    var column = point.Column;
    var row = point.Row;
    var listOfNeighbours = new List<Point>();
    if (column != 0 && map[column - 1, row] != "█")
    {
        var upperNeighbour = new Point(column - 1, row);
        listOfNeighbours.Add(upperNeighbour);
    }

    if (column + 1 != globalWidth && map[column + 1, row] != "█")
    {
        var lowerNeighbour = new Point(column + 1, row);
        listOfNeighbours.Add(lowerNeighbour);
    }

    if (row != 0 && map[column, row - 1] != "█")
    {
        var leftNeighbour = new Point(column, row - 1);
        listOfNeighbours.Add(leftNeighbour);
    }

    if (row + 1 != globalHeight && map[column, row + 1] != "█")
    {
        var rightNeighbour = new Point(column, row + 1);
        listOfNeighbours.Add(rightNeighbour);
    }

    return listOfNeighbours;
}


int CostOfMovement(Point firstPoint, Point secondPoint)
{
    if (firstPoint.Column == secondPoint.Column && firstPoint.Row == secondPoint.Row) return 0;

    if (firstPoint.Column == secondPoint.Column && firstPoint.Row != secondPoint.Row) return 1;

    if (firstPoint.Column != secondPoint.Column && firstPoint.Row == secondPoint.Row) return 1;

    return 1;
}

var printer = new MapPrinter();
printer.Print(maze, path);