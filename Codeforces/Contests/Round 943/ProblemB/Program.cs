namespace ProblemB;

internal static class Program
{
    private static void Solve()
    {
        var input = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
        var strA = Console.ReadLine()!;
        var strB = Console.ReadLine()!;
        var lenA = input[0];
        var lenB = input[1];

        var ptrA = 0;

        for (var ptrB = 0; ptrB < lenB; ++ptrB)
        {
            if (strA[ptrA] == strB[ptrB]) ++ptrA;

            if (ptrA == lenA) break;
        }

        Console.WriteLine(ptrA);
    }

    internal static void Main(string[] _)
    {
        var testCases = int.Parse(Console.ReadLine()!);

        while (testCases-- > 0) Solve();
    }
}