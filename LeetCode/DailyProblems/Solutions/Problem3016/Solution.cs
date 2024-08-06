namespace DailyProblems.Solutions.Problem3016;

public class Solution
{
    private const int TotalKeys = 8;
    private const int TotalLetters = 26;

    public int MinimumPushes(string word)
    {
        var letterCount = new int[TotalLetters];

        foreach (var letter in word)
        {
            ++letterCount[letter - 'a'];
        }

        Array.Sort(letterCount, (a, b) => b.CompareTo(a));

        var ans = 0;

        for (var i = 0; i < TotalLetters; ++i)
        {
            ans += letterCount[i] * (i / TotalKeys + 1);
        }

        return ans;
    }
}