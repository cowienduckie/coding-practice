namespace DailyProblems;

internal static class Program
{
    internal static void Main(string[] _)
    {
        var solution = new Solutions.Problem2392.Solution();

        var rowConditions = new[]
        {
            new[] { 1, 2 },
            new[] { 2, 3 },
            new[] { 3, 1 },
            new[] { 2, 3 }
        };

        var colConditions = new[]
        {
            new[] { 2, 1 }
        };

        var ans = solution.BuildMatrix(3, rowConditions, colConditions);

        foreach (var row in ans)
        {
            foreach (var cell in row)
            {
                Console.Write(cell + " ");
            }

            Console.WriteLine();
        }
    }
}