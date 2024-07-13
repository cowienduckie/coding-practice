// Description: https://leetcode.com/problems/intersection-of-two-arrays-ii

namespace DailyProblems.Solutions.Problem350;

public class Solution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        var ans = new List<int>();

        Array.Sort(nums1);
        Array.Sort(nums2);

        var ptr1 = 0;
        var ptr2 = 0;

        while (ptr1 < nums1.Length && ptr2 < nums2.Length)
            if (nums1[ptr1] == nums2[ptr2])
            {
                ans.Add(nums1[ptr1]);
                ++ptr1;
                ++ptr2;
            }
            else if (nums1[ptr1] < nums2[ptr2])
            {
                ++ptr1;
            }
            else if (nums1[ptr1] > nums2[ptr2])
            {
                ++ptr2;
            }

        return ans.ToArray();
    }
}