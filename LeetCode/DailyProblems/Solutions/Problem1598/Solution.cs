namespace DailyProblems.Solutions.Problem1598;

public class Solution
{
    public int MinOperations(string[] logs)
    {
        var level = 0;

        foreach (var operation in logs)
        {
            switch (operation)
            {
                case "../":
                    if (level != 0) --level;
                    break;
                case "./":
                    break;
                default:
                    ++level;
                    break;
            }
        }

        return level;
    }
}