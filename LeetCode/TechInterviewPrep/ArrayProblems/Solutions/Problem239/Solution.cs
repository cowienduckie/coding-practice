namespace ArrayProblems.Solutions.Problem239;

public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var n = nums.Length;
        var ans = new List<int>();

        // Store indexes of number in current window
        // First element is always the max of window -> Only keep the elements after max, not the before
        // The deque is always in DESC order
        var deque = new LinkedList<int>();

        for (var i = 0; i < n; ++i)
        {
            // Remove elements no more in window
            while (deque.First != null && deque.First.Value < i - k + 1)
            {
                deque.RemoveFirst();
            }

            // Remove all smaller elements to maintain the DESC order
            while (deque.Last != null && nums[deque.Last.Value] < nums[i])
            {
                deque.RemoveLast();
            }

            deque.AddLast(i);

            // The window start sliding after the k - 1 element
            // So, start record the max from the k - 1
            if (i >= k - 1)
            {
                ans.Add(nums[deque.First!.Value]);
            }
        }

        return ans.ToArray();
    }
}