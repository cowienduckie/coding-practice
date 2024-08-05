namespace DailyProblems.Solutions.Problem1508;

public class Solution
{
    private const int Mod = 1000000007;

    public int RangeSum(int[] nums, int n, int left, int right)
    {
        var sumList = new List<int>();

        for (var i = 0; i < n; ++i)
        {
            var sum = 0;

            for (var j = i; j < n; ++j)
            {
                sum += nums[j];
                sumList.Add(sum);
            }
        }

        sumList.Sort();

        var ans = 0;

        for (var i = left - 1; i < right; ++i)
        {
            ans = (ans + sumList[i] % Mod) % Mod;
        }

        return ans;
    }
}