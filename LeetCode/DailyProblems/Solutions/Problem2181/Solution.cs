namespace DailyProblems.Solutions.Problem2181;

public class ListNode
{
    public ListNode next;
    public int val;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    private void Traverse(ListNode prev, ListNode curr)
    {
        // Base case: the end of the list, remove the last 0
        if (curr.next == null)
        {
            prev.next = null;

            return;
        }

        // Go to end of list, sum of integers in a group into the 0 nodes
        if (curr.val == 0)
        {
            Traverse(curr, curr.next);
        }
        else
        {
            prev.val += curr.val;
            prev.next = curr.next;

            Traverse(prev, curr.next);
        }
    }


    public ListNode MergeNodes(ListNode head)
    {
        Traverse(head, head.next);

        return head;
    }
}