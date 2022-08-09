namespace DijkstraSearch;

public class MapPrinter
{
    public void Print(string[,] maze, List<Point> path)
    {
        foreach (var point in path)
        {
            if (path.Count == 0) break;

            if (maze[point.Column, point.Row] == "A" || maze[point.Column, point.Row] == "B") continue;
            maze[point.Column, point.Row] = "*";
        }

        PrintTopLine();
        for (var row = 0; row < maze.GetLength(1); row++)
        {
            Console.Write($"{row}\t");
            for (var column = 0; column < maze.GetLength(0); column++) Console.Write(maze[column, row]);

            Console.WriteLine();
        }

        void PrintTopLine()
        {
            Console.Write(" \t");
            for (var i = 0; i < maze.GetLength(0); i++) Console.Write(i % 10 == 0 ? i / 10 : " ");

            Console.Write("\n \t");
            for (var i = 0; i < maze.GetLength(0); i++) Console.Write(i % 10);

            Console.WriteLine("\n");
        }
    }
}