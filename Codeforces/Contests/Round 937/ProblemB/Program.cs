namespace ProblemB;

internal static class Program
{
    private const char Sharp = '#';
    private const char Dot = '.';

    private static void SwapChar(ref char currChar)
    {
        currChar = currChar == Sharp ? Dot : Sharp;
    }

    private static void DrawLine(char firstChar, int size)
    {
        var currChar = firstChar;

        for (var col = 0; col < size; ++col)
        {
            Console.Write(currChar);

            if ((col & 1) == 1) SwapChar(ref currChar);
        }

        Console.WriteLine();
    }

    private static void Solve()
    {
        var size = int.Parse(Console.ReadLine()!) * 2;
        var firstChar = Sharp;

        for (var row = 0; row < size; ++row)
        {
            DrawLine(firstChar, size);

            if ((row & 1) == 1) SwapChar(ref firstChar);
        }
    }

    internal static void Main(string[] _)
    {
        var testCases = int.Parse(Console.ReadLine()!);

        while (testCases-- > 0) Solve();
    }
}