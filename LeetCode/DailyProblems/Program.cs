namespace DailyProblems;

internal static class Program
{
    internal static void Main(string[] _)
    {
        var solution = new Solutions.Problem1509.Solution();

        var ans = solution.MinDifference(new[] { 9,48,92,48,81,31 });

        Console.WriteLine(ans);
    }
}