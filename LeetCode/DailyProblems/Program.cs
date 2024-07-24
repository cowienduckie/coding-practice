namespace DailyProblems;

internal static class Program
{
    internal static void Main(string[] _)
    {
        var solution = new Solutions.Problem2191.Solution();

        var ans = solution.SortJumbled(new []{ 5,6,8,7,4,0,3,1,9,2 }, new []{ 7686,97012948,84234023,2212638,99 });

        foreach (var num in ans)
        {
            Console.Write(num + " ");
        }
    }
}