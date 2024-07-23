namespace DailyProblems;

internal static class Program
{
    internal static void Main(string[] _)
    {
        var solution = new Solutions.Problem1636.Solution();

        var ans = solution.FrequencySort(new []{ 1, 1, 2, 2, 2, 3 });

        foreach (var num in ans)
        {
            Console.Write(num + " ");
        }
    }
}