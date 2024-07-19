namespace ArrayProblems.Solutions.Problem121;

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var ans = 0;

        var low = prices[0];
        var high = prices[0];

        for (var i = 1; i < prices.Length; ++i)
        {
            if (low > prices[i])
            {
                ans = Math.Max(ans, high - low);

                low = prices[i];
                high = prices[i];
            }

            high = Math.Max(high, prices[i]);
        }

        return Math.Max(ans, high - low);
    }
}