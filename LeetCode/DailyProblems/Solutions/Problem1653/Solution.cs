namespace DailyProblems.Solutions.Problem1653;

public class Solution
{
    public int MinimumDeletions(string s)
    {
        var ans = 0;
        var countB = 0;

        foreach (var chr in s)
        {
            if (chr == 'b')
            {
                ++countB;
            }
            else
            {
                ans = Math.Min(ans + 1, countB);
            }
        }

        return ans;
    }
}

// public class Solution
// {
//     public int MinimumDeletions(string s)
//     {
//         var aRight = new int[s.Length];
//         var counter = 0;
//
//         for (var i = s.Length - 1; i >= 0; --i)
//         {
//             aRight[i] = counter;
//
//             if (s[i] == 'a')
//             {
//                 ++counter;
//             }
//         }
//
//         var ans = int.MaxValue;
//         counter = 0;
//
//         for (var i = 0; i < s.Length; ++i)
//         {
//             ans = Math.Min(ans, counter + aRight[i]);
//
//             if (s[i] == 'b')
//             {
//                 ++counter;
//             }
//         }
//
//         return ans;
//     }
// }