namespace ProblemC;

internal static class Program
{
    private static void Solve()
    {
        var num = int.Parse(Console.ReadLine()!);
        var mod = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();

        var result = new List<int> { mod[0] + 1 };

        for (var i = 0; i < num - 2; ++i)
        {
            var j = 0;

            while (mod[i] + j * result[i] <= mod[i + 1]) ++j;

            result.Add(mod[i] + j * result[i]);
        }

        result.Add(mod[num - 2]);

        Console.WriteLine(string.Join(' ', result));
    }

    internal static void Main(string[] _)
    {
        var testCases = int.Parse(Console.ReadLine()!);

        while (testCases-- > 0) Solve();
    }
}