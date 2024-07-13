using System.Collections.Immutable;

namespace ProblemB;

internal static class Program
{
    private static void Solve()
    {
        var charCount = int.Parse(Console.ReadLine()!);
        var inputString = Console.ReadLine()!.ToCharArray();

        var charSet = inputString.ToImmutableSortedSet();
        var hashDict = new Dictionary<char, char>();

        for (var i = 0; i < charSet.Count; i++) hashDict.Add(charSet[i], charSet[charSet.Count - i - 1]);

        foreach (var c in inputString) Console.Write(hashDict[c]);

        Console.WriteLine();
    }

    internal static void Main(string[] _)
    {
        var testCases = int.Parse(Console.ReadLine()!);

        while (testCases-- > 0) Solve();
    }
}