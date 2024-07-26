namespace ProblemA;

internal static class Program
{
    private static void Solve()
    {
        var legs = int.Parse(Console.ReadLine()!);
        var cows = legs / 4;

        Console.WriteLine(cows + (legs % 4 == 0 ? 0 : 1));
    }

    internal static void Main(string[] _)
    {
        var testCases = int.Parse(Console.ReadLine()!);

        while (testCases-- > 0) Solve();
    }
}