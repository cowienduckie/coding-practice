namespace DailyProblems;

internal static class Program
{
    internal static void Main(string[] _)
    {
        var solution = new Solutions.Problem3016.Solution();

        var ans = solution.MinimumPushes("aabbccccde");

        Console.WriteLine(ans);
    }
}