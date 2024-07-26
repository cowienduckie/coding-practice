namespace ProblemB;

internal static class Program
{
    private static void Solve()
    {
        var input = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();

        var n = input[0];
        var k = input[1];

        for (var row = 0; row < n; row++)
        {
            string cells = Console.ReadLine()!;

            if (row % k == 0)
            {
                for (var col = 0; col < n; col += k)
                {
                    Console.Write(cells[col]);
                }

                Console.WriteLine();
            }
        }
    }

    internal static void Main(string[] _)
    {
        var testCases = int.Parse(Console.ReadLine()!);

        while (testCases-- > 0) Solve();
    }
}