namespace DailyProblems.Solutions.Problem2976;

public class Solution
{
    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
    {
        var convert = new long[26][];

        for (var i = 0; i < 26; ++i)
        {
            convert[i] = new long[26];

            for (var j = 0; j < 26; ++j)
            {
                convert[i][j] = i == j ? 0 : long.MaxValue;
            }
        }

        for (var i = 0; i < cost.Length; ++i)
        {
            var src = original[i] - 'a';
            var dst = changed[i] - 'a';

            convert[src][dst] = Min(convert[src][dst], cost[i]);
        }

        for (var k = 0; k < 26; ++k)
        {
            for (var i = 0; i < 26; ++i)
            {
                for (var j = 0; j < 26; ++j)
                {
                    if (convert[i][k] != long.MaxValue && convert[k][j] != long.MaxValue)
                    {
                        convert[i][j] = Min(convert[i][j], convert[i][k] + convert[k][j]);
                    }
                }
            }
        }

        long totalCost = 0;

        for (var i = 0; i < source.Length; ++i)
        {
            if (source[i] == target[i])
            {
                continue;
            }

            var src = source[i] - 'a';
            var dst = target[i] - 'a';

            if (convert[src][dst] == long.MaxValue)
            {
                return -1;
            }

            totalCost += convert[src][dst];
        }

        return totalCost;
    }

    private static long Min(long a, long b) => a < b ? a : b;
}