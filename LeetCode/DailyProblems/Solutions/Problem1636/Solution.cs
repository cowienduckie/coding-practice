namespace DailyProblems.Solutions.Problem1636;

public class Solution
{
    public int[] FrequencySort(int[] nums)
    {
        var dict = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (!dict.TryAdd(num, 1))
            {
                ++dict[num];
            }
        }

        return dict
            .OrderBy(x => x.Value)
            .ThenByDescending(x => x.Key)
            .SelectMany(x => Enumerable.Repeat(x.Key, x.Value))
            .ToArray();
    }
}