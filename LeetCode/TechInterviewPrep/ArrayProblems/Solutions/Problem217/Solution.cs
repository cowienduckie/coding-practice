namespace ArrayProblems.Solutions.Problem217;

public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        if(nums.Length == 1)
        {
            return false;
        }

        var set = new HashSet<int>();

        return nums.Any(num => !set.Add(num));
    }
}