namespace DailyProblems.Solutions.Problem1701;

public class Solution
{
    public double AverageWaitingTime(int[][] customers)
    {
        double totalWaitTime = 0;

        var chefTime = 0;
        var queue = new Queue<int[]>(customers);

        while (queue.Count != 0)
        {
            var customer = queue.Dequeue();
            var arrivalTime = customer[0];
            var cookingTime = customer[1];

            if (chefTime == arrivalTime) // Customer comes right when the chef finishes previous order
            {
                totalWaitTime += cookingTime;
                chefTime += cookingTime;
            }
            else if (chefTime < arrivalTime) // Customer comes after the chef finishes previous order
            {
                totalWaitTime += cookingTime;
                chefTime = arrivalTime + cookingTime;
            }
            else if (chefTime > arrivalTime) // Customer comes before the chef finishes previous order
            {
                totalWaitTime += chefTime - arrivalTime + cookingTime;
                chefTime += cookingTime;
            }
        }

        return totalWaitTime / customers.Length;
    }
}