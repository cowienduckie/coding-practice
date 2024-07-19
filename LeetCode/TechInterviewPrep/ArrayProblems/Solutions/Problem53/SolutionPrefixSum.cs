namespace ArrayProblems.Solutions.Problem53;

public class SolutionPrefixSum
{
    public int MaxSubArray(int[] nums)
    {
        var ans = int.MinValue;
        var sum = 0;

        foreach (var num in nums)
        {
            sum += num;

            if (num > sum)
            {
                sum = num;
            }

            ans = Math.Max(ans, sum);
        }

        return ans;
    }
}