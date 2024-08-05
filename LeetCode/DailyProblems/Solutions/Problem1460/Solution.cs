namespace DailyProblems.Solutions.Problem1460;

public class Solution
{
    public bool CanBeEqual(int[] target, int[] arr)
    {
        var targetDict = target
            .GroupBy(x => x)
            .ToDictionary(x => x.Key, x => x.Count());

        foreach (var num in arr)
        {
            if (!targetDict.ContainsKey(num) || targetDict[num] == 0)
            {
                return false;
            }

            --targetDict[num];
        }

        return true;
    }
}