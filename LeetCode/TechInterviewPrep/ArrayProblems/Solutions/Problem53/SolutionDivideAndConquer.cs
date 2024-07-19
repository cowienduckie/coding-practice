namespace ArrayProblems.Solutions.Problem53;

public class SolutionDivideAndConquer
{
    public int MaxSubArray(int[] nums)
    {
        return MaxSum(nums, 0, nums.Length - 1);
    }

    private static int MaxSum(int[] nums, int left, int right)
    {
        if (left == right)
        {
            return nums[left];
        }

        var mid = left + (right - left) / 2;

        var leftSum = MaxSum(nums, left, mid);
        var rightSum = MaxSum(nums, mid + 1, right);


        var crossSum = CrossSum(nums, left, right, mid);

        return Math.Max(Math.Max(leftSum, rightSum), crossSum);
    }

    private static int CrossSum(int[] nums, int left, int right, int mid)
    {
        if (left == right)
        {
            return nums[left];
        }

        var leftSum = int.MinValue;
        var currSum = 0;

        for (var i = mid; i > left - 1; --i)
        {
            currSum += nums[i];
            leftSum = Math.Max(leftSum, currSum);
        }

        var rightSum = int.MinValue;
        currSum = 0;

        for (var i = mid + 1; i < right + 1; ++i)
        {
            currSum += nums[i];
            rightSum = Math.Max(rightSum, currSum);
        }

        return leftSum + rightSum;
    }
}