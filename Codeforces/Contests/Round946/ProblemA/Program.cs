namespace ProblemA;

internal static class Program
{
    private static void Solve()
    {
        var input = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
        var smallIcons = input[0];
        var largeIcons = input[1];

        var minimumScreens = (int)Math.Ceiling((double)largeIcons / 2);
        var singleCells = 7 * minimumScreens + (2 * minimumScreens - largeIcons) * 4;

        if (smallIcons <= singleCells)
        {
            Console.WriteLine(minimumScreens);
        }
        else
        {
            var additionalScreens = (int)Math.Ceiling((double)(smallIcons - singleCells) / 15);

            Console.WriteLine(minimumScreens + additionalScreens);
        }
    }

    internal static void Main(string[] _)
    {
        var testCases = int.Parse(Console.ReadLine()!);

        while (testCases-- > 0) Solve();
    }
}