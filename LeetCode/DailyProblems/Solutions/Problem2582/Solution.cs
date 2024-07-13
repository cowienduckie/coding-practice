namespace DailyProblems.Solutions.Problem2582;

public class Solution
{
    public int PassThePillow(int n, int time)
    {
        var completedTurn = time / (n - 1);
        var timeLeft = time % (n - 1);

        if ((completedTurn & 1) == 0)
            return timeLeft + 1;
        return n - timeLeft;
    }
}