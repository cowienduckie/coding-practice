namespace DailyProblems.Solutions.Problem237;

public class Solution
{
    private static readonly Dictionary<string, string> ToWord = new()
    {
        { "0", "" },
        { "1", "One" },
        { "2", "Two" },
        { "3", "Three" },
        { "4", "Four" },
        { "5", "Five" },
        { "6", "Six" },
        { "7", "Seven" },
        { "8", "Eight" },
        { "9", "Nine" },
        { "10", "Ten"},

        { "11", "Eleven" },
        { "12", "Twelve" },
        { "13", "Thirteen" },
        { "14", "Fourteen" },
        { "15", "Fifteen" },
        { "16", "Sixteen" },
        { "17", "Seventeen" },
        { "18", "Eighteen" },
        { "19", "Nineteen" },

        { "20", "Twenty" },
        { "30", "Thirty" },
        { "40", "Forty" },
        { "50", "Fifty" },
        { "60", "Sixty" },
        { "70", "Seventy" },
        { "80", "Eighty" },
        { "90", "Ninety" },
    };

    public string NumberToWords(int num)
    {
        var ans = string.Empty;
        var groups = new List<int>();

        while (num > 0)
        {
            groups.Add(num % 1000);

            num /= 1000;
        }

        for (var i = groups.Count - 1; i >= 0; i--)
        {
            if (groups[i] == 0)
            {
                continue;
            }

            ans += ConvertThreeDigit(groups[i]) + " " + new[] { "", "Thousand", "Million", "Billion" }[i] + " ";
        }

        return ans.Trim() == string.Empty ? "Zero" : ans.Trim();
    }

    private static string ConvertThreeDigit(int num)
    {
        var ans = string.Empty;
        var str = num.ToString("000");

        if (str[0] != '0')
        {
            ans += ToWord[str[0].ToString()] + " Hundred " + ConvertTwoDigit(str.Substring(1));
        }
        else
        {
            ans += ConvertTwoDigit(str.Substring(1));
        }

        return ans.Trim();
    }

    private static string ConvertTwoDigit(string str)
    {
        return str[0] switch
        {
            '0' => ToWord[str[1].ToString()],
            '1' => ToWord[str[0] + str[1].ToString()],
            _ => (ToWord[str[0] + "0"] + " " + ToWord[str[1].ToString()]).Trim()
        };
    }
}