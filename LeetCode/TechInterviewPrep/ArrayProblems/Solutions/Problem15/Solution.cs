namespace ArrayProblems.Solutions.Problem15;

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var n = nums.Length;

        if (n < 3)
        {
            return new List<IList<int>>();
        }

        Array.Sort(nums);

        var result = new List<IList<int>>();

        for (var i = 0; i < n - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }

            var left = i + 1;
            var right = n - 1;

            while (left < right)
            {
                var sum = nums[i] + nums[left] + nums[right];

                if (sum == 0)
                {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });

                    while (left < right && nums[left] == nums[left + 1])
                    {
                        left++;
                    }

                    while (left < right && nums[right] == nums[right - 1])
                    {
                        right--;
                    }

                    left++;
                    right--;
                }
                else if (sum < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        return result;
    }
}