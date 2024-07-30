namespace ArrayProblems;

internal static class Program
{
    internal static void Main(string[] _)
    {
        var solution = new Solutions.Problem239.Solution();

        var ans = solution.MaxSlidingWindow(new []{ 1,3,-1,-3,5,3,6,7 }, 3);

        foreach (var num in ans)
        {
            Console.Write(num + " ");
        }
    }
}