namespace DailyProblems;

internal static class Program
{
    internal static void Main(string[] _)
    {
        var solution = new Solutions.Problem1395.Solution();

        var ans = solution.NumTeams(new [] { 1, 2, 3, 4 });

        Console.WriteLine(ans);
    }
}