namespace DailyProblems.Solutions.Problem1518;

public class Solution
{
    private static int ExchangeBottles(int numLeft, int numExchange)
    {
        if (numLeft < numExchange) return 0;

        var numFilled = numLeft / numExchange;
        var numEmpty = numLeft % numExchange;

        return numFilled + ExchangeBottles(numFilled + numEmpty, numExchange);
    }

    public int NumWaterBottles(int numBottles, int numExchange)
    {
        if (numBottles == 1) return 1;

        return numBottles + ExchangeBottles(numBottles, numExchange);
    }
}