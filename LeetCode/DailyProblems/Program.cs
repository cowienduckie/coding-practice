namespace DailyProblems;

internal static class Program
{
    internal static void Main(string[] _)
    {
        var solution = new Solutions.Problem1653.Solution();

        var ans = solution.MinimumDeletions("aabbaababbababaabbbaabbbbaababababbabbbababbabbaabaaabbbbbbaaabbbbabaababbaaabbbbaaabababbbaaa");

        Console.WriteLine(ans);
    }
}