namespace DailyProblems.Solutions.Problem1823;

public class Solution
{
    public int FindTheWinner(int n, int k)
    {
        var queue = new Queue<int>(Enumerable.Range(1, n));
        var counter = k;

        while (queue.Count > 1)
        {
            var head = queue.Dequeue();

            if (--counter == 0)
                counter = k;
            else
                queue.Enqueue(head);
        }

        return queue.Dequeue();
    }
}