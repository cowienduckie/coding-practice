namespace ProblemA;

internal static class Program
{
    private static void Solve()
    {
        var input = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();

        if (input[0] >= input[1])
        {
            Console.WriteLine("NONE");
            return;
        }

        if (input[1] < input[2])
        {
            Console.WriteLine("STAIR");
            return;
        }

        if (input[1] > input[2])
        {
            Console.WriteLine("PEAK");
            return;
        }

        Console.WriteLine("NONE");
    }

    internal static void Main(string[] _)
    {
        var testCases = int.Parse(Console.ReadLine()!);

        while (testCases-- > 0) Solve();
    }
}