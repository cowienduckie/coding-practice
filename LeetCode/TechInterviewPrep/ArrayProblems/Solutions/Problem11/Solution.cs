namespace ArrayProblems.Solutions.Problem11;

public class Solution
{
    public int MaxArea(int[] height)
    {
        var l = 0;
        var r = height.Length - 1;
        var ans = int.MinValue;

        while (l < r)
        {
            ans = Math.Max(ans, Math.Min(height[l], height[r]) * (r - l));

            if (height[l] < height[r])
            {
                ++l;
            }
            else
            {
                --r;
            }
        }

        return ans;
    }
}