namespace DailyProblems.Solutions.Problem2053;

public class Solution
{
    public string KthDistinct(string[] arr, int k)
    {
        var dict = arr
            .GroupBy(x => x)
            .ToDictionary(x => x.Key, x => x.Count());

        var counter = 0;

        foreach (var str in arr)
        {
            if (dict[str] != 1)
            {
                continue;
            }

            ++counter;

            if (counter == k)
            {
                return str;
            }
        }

        return string.Empty;
    }
}