namespace ProblemC;

internal static class Program
{
    private static void Solve()
    {
        var input = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
        var n = input[0];
        var q = input[1];

        var strA = Console.ReadLine()!;
        var strB = Console.ReadLine()!;

        var prefixA = new int[n + 1, 26];
        var prefixB = new int[n + 1, 26];

        for (var i = 0; i < n; ++i)
        {
            for (var j = 0; j < 26; ++j)
            {
                prefixA[i + 1, j] = prefixA[i, j];
                prefixB[i + 1, j] = prefixB[i, j];
            }
            prefixA[i + 1, strA[i] - 'a']++;
            prefixB[i + 1, strB[i] - 'a']++;
        }

        while (q-- > 0)
        {
            input = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
            var l = input[0];
            var r = input[1];

            var dict = new Dictionary<char, int>();

            for (var i = 0; i < 26; ++i)
            {
                var countA = prefixA[r, i] - prefixA[l - 1, i];
                var countB = prefixB[r, i] - prefixB[l - 1, i];
                var diff = countB - countA;
                if (diff > 0)
                {
                    dict[(char)(i + 'a')] = diff;
                }
            }

            Console.WriteLine(dict.Values.Sum());
        }
    }

    internal static void Main(string[] _)
    {
        var testCases = int.Parse(Console.ReadLine()!);

        while (testCases-- > 0) Solve();
    }
}