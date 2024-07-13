namespace DailyProblems;

internal static class Program
{
    internal static void Main(string[] _)
    {
        var solution = new Solutions.Problem2751.Solution();

        var ans = solution.SurvivedRobotsHealths(new [] { 3,5,2,6 }, new []{ 10,10,15,12 }, "RLRL");

        Console.WriteLine(string.Join(", ", ans));
    }
}