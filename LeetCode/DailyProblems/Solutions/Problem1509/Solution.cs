namespace DailyProblems.Solutions.Problem1509;

public class Solution
{
    private const int MaximumStep = 3;

    private static int Solve(int[] nums, int left, int right, int pos, int ans)
    {
        if (pos > MaximumStep) return ans;

        return Math.Min(
            Solve(nums, left + 1, right, pos + 1, Math.Min(ans, nums[right] - nums[left])),
            Solve(nums, left, right - 1, pos + 1, Math.Min(ans, nums[right] - nums[left]))
        );
    }

    public int MinDifference(int[] nums)
    {
        // Base cases: 1-4 elements
        if (nums.Length >= 1 && nums.Length <= 4) return 0;

        // Array has more than 4 elements
        Array.Sort(nums);

        return Solve(nums, 0, nums.Length - 1, 0, int.MaxValue);
    }
}