namespace DailyProblems.Solutions.Problem1717;

public class Solution
{
    private static int RemoveSubstrings(
        IEnumerable<char> source,
        char[] subString,
        int point,
        out IEnumerable<char> charLeft)
    {
        var stack = new Stack<char>();
        var totalPoint = 0;

        foreach (var chr in source)
        {
            if (chr == subString[1] && stack.Count > 0 && stack.Peek() == subString[0])
            {
                totalPoint += point;
                stack.Pop();
            }
            else
            {
                stack.Push(chr);
            }
        }

        charLeft = stack;

        return totalPoint;
    }

    public int MaximumGain(string s, int x, int y)
    {
        var firstPoint = Math.Max(x, y);
        var secondPoint = Math.Min(x, y);

        var subString = x > y
            ? new[] { 'a', 'b' }
            : new[] { 'b', 'a' };

        return RemoveSubstrings(s, subString, firstPoint, out var charLeft) +
               RemoveSubstrings(charLeft, subString, secondPoint, out _);
    }
}