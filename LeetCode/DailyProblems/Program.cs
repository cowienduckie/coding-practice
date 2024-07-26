namespace DailyProblems;

internal static class Program
{
    internal static void Main(string[] _)
    {
        var solution = new Solutions.Problem1334.SolutionFloydWarshall();

        var edges = new[]
        {
            new[] { 0, 1, 10 },
            new[] { 0, 2, 1 },
            new[] { 2, 3, 1 },
            new[] { 1, 3, 1 },
            new[] { 1, 4, 1 },
            new[] { 4, 5, 10 }
        };

        var ans = solution.FindTheCity(6, edges, 20);

        Console.WriteLine(ans);
    }
}