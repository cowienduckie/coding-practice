namespace ProblemD;

internal static class Program
{
    private const int MaxValue = (int)1e5 + 7;
    private static readonly List<int> BinaryDecimals = new();

    private static bool Validate(int input)
    {
        if (input == 1) return true;

        var result = false;

        foreach (var binaryDecimal in BinaryDecimals)
        {
            if (input % binaryDecimal != 0) continue;

            result |= Validate(input / binaryDecimal);

            if (result) break;
        }

        return result;
    }

    private static void Solve()
    {
        var input = int.Parse(Console.ReadLine()!);

        Console.WriteLine(Validate(input) ? "YES" : "NO");
    }

    private static void Prepare(int number)
    {
        if (number > MaxValue) return;

        BinaryDecimals.Add(number);

        Prepare(number * 10);
        Prepare(number * 10 + 1);
    }

    internal static void Main(string[] _)
    {
        var testCases = int.Parse(Console.ReadLine()!);

        Prepare(1);
        BinaryDecimals.RemoveAt(0);

        while (testCases-- > 0) Solve();
    }
}