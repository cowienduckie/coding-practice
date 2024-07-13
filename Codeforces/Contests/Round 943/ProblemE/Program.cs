namespace ProblemE;

internal static class Program
{
    private static void Solve()
    {
        var num = int.Parse(Console.ReadLine()!);

        Console.WriteLine("1 1");
        Console.WriteLine("1 2");

        for (var i = 3; i <= num; ++i) Console.WriteLine(i + " " + i);

        Console.WriteLine();
    }

    internal static void Main(string[] _)
    {
        var testCases = int.Parse(Console.ReadLine()!);

        while (testCases-- > 0) Solve();
    }
}