namespace ArrayProblems.Solutions.Problem238;

public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var ans = new int[nums.Length];
        var prod = 1;
        var temp = 1;

        for (var i = 0; i < nums.Length; ++i)
        {
            temp = nums[i];
            nums[i] = prod;
            prod = prod * temp;
        }

        prod = 1;

        for (var i = nums.Length - 1; i >= 0; --i)
        {
            ans[i] = ans[i] * prod;
            prod = prod * nums[i];
        }

        return ans;
    }
}