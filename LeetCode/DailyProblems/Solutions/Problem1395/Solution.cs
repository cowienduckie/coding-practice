namespace DailyProblems.Solutions.Problem1395;

public class Solution
{
    public int NumTeams(int[] rating)
    {
        var less = new int[rating.Length];
        var greater = new int[rating.Length];
        var ans = 0;

        for (var i = rating.Length - 1; i >= 0; --i)
        {
            for (var j = i + 1; j < rating.Length; ++j)
            {
                if (rating[i] > rating[j])
                {
                    ++greater[i];
                    ans += greater[j];
                }
                else if (rating[i] < rating[j])
                {
                    ++less[i];
                    ans += less[j];
                }
            }
        }

        return ans;
    }
}