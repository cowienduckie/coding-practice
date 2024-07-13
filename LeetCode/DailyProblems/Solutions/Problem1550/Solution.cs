// URL: https://leetcode.com/problems/three-consecutive-odds/

namespace DailyProblems.Solutions.Problem1550;

public class Solution
{
    public bool ThreeConsecutiveOdds(int[] arr)
    {
        var counter = 0;

        foreach (var num in arr)
            if ((num & 1) == 1)
            {
                ++counter;

                if (counter == 3) return true;
            }
            else
            {
                counter = 0;
            }

        return false;
    }
}