namespace DailyProblems.Solutions.Problem2134;

public class Solution
{
    public int MinSwaps(int[] nums)
    {
        var n = nums.Length;

        var totalOnes = 0;
        for (var i = 0; i < n; ++i)
        {
            totalOnes += nums[i] == 1 ? 1 : 0;
        }

        if (totalOnes == 0 || totalOnes == n)
        {
            return 0;
        }

        var countOnes = 0;
        for (var i = 0; i < totalOnes; ++i)
        {
            countOnes += nums[i] == 1 ? 1 : 0;
        }

        var ans = totalOnes - countOnes;
        for (var left = 1; left < n; ++left)
        {
            var right = left + totalOnes - 1;

            if (right >= n)
            {
                right -= n;
            }

            if (nums[left - 1] == 1)
            {
                --countOnes;
            }

            if (nums[right] == 1)
            {
                ++countOnes;
            }

            ans = Math.Min(ans, totalOnes - countOnes);
        }

        return ans;
    }
}