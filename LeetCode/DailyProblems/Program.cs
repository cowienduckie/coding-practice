namespace DailyProblems;

internal static class Program
{
    internal static void Main(string[] _)
    {
        var solution = new Solutions.Problem959.Solution();

        var grid = new []
        {
            "//",
            "/ "
        };

        // 0 1 0 1
        // 1 0 1 0
        //
        //

        var ans = solution.RegionsBySlashes(grid);

        Console.WriteLine(ans);
    }
}