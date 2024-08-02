namespace DailyProblems.Solutions.Problem2678;

public class Solution
{
    public int CountSeniors(string[] details)
    {
        return details.Count(x => x[11] > '6' || (x[11] == '6' && x[12] > '0'));
    }
}