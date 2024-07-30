namespace ArrayProblems.Solutions.Problem152;

public class Solution
{
    public int MaxProduct(int[] nums)
    {
        double ans = double.MinValue;
        double currMin = 1;
        double currMax = 1;

        foreach (var num in nums)
        {
            if (num < 0)
            {
                (currMax, currMin) = (currMin, currMax);
            }

            currMax = Math.Max(currMax * num, num);
            currMin = Math.Min(currMin * num, num);

            ans = Math.Max(ans, currMax);
        }

        return (int)ans;
    }
}

// public class Solution
// {
//     public int MaxProduct(int[] nums)
//     {
//         double ans = double.MinValue;
//         double leftProd = 1;
//         double rightProd = 1;
//
//         for (int l = 0, r = nums.Length - 1; l < nums.Length; ++l, --r)
//         {
//             leftProd = (leftProd == 0 ? 1 : leftProd) * nums[l];
//             rightProd = (rightProd == 0 ? 1 : rightProd) * nums[r];
//
//             ans = Math.Max(ans, Math.Max(leftProd, rightProd));
//         }
//
//         return (int)ans;
//     }
// }