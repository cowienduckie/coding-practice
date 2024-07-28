namespace DailyProblems;

internal static class Program
{
    internal static void Main(string[] _)
    {
        var solution = new Solutions.Problem2045.Solution();

        // [[1,2],[1,3],[2,4],[3,5],[5,4],[4,6]]
        var edges = new[]
        {
            new[] { 1, 2 },
            new[] { 1, 3 },
            new[] { 2, 4 },
            new[] { 3, 5 },
            new[] { 5, 4 },
            new[] { 4, 6 }
        };

        var ans = solution.SecondMinimum(6, edges, 3, 100);

        Console.WriteLine(ans);
    }
}