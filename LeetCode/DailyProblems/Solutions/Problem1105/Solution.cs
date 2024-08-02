namespace DailyProblems.Solutions.Problem1105;

public class Solution
{
    public int MinHeightShelves(int[][] books, int shelfWidth)
    {
        var n = books.Length;
        var dp = new int[n + 1];

        dp[n] = 0;

        for (var i = n - 1; i >= 0; --i)
        {
            var currWidth = 0;
            var currHeight = 0;

            dp[i] = int.MaxValue;

            for (var j = i; j < n; ++j)
            {
                currWidth += books[j][0];

                if (currWidth > shelfWidth)
                {
                    break;
                }

                currHeight = Math.Max(currHeight, books[j][1]);

                dp[i] = Math.Min(dp[i], currHeight + dp[j + 1]);
            }
        }

        return dp[0];
    }
}