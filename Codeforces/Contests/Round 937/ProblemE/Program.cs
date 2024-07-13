namespace ProblemE;

internal static class Program
{
    private static List<int> GetDivisors(int num)
    {
        var divisors = new List<int>();

        for (var i = 1; i <= num / 2; ++i)
            if (num % i == 0)
                divisors.Add(i);

        return divisors;
    }

    private static bool IsAtMostOneCharDifferent(string a, string b)
    {
        var diffCount = 0;

        for (var i = 0; i < a.Length; ++i)
        {
            if (a[i] != b[i]) ++diffCount;

            if (diffCount > 1) return false;
        }

        return true;
    }

    private static void Solve()
    {
        var strLen = int.Parse(Console.ReadLine()!);
        var str = Console.ReadLine()!;

        var result = strLen;

        foreach (var divisor in GetDivisors(strLen))
        {
            var chunks = str
                .Chunk(divisor)
                .Select(x => new string(x))
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());

            if (chunks.Count == 1)
            {
                result = divisor;
                break;
            }

            if (chunks.Count > 2) continue;

            if (chunks.Values.All(count => count > 1)) continue;

            if (IsAtMostOneCharDifferent(chunks.Keys.First(), chunks.Keys.Last()))
            {
                result = divisor;
                break;
            }
        }

        Console.WriteLine(result);
    }

    internal static void Main(string[] _)
    {
        var testCases = int.Parse(Console.ReadLine()!);

        while (testCases-- > 0) Solve();
    }
}