namespace DailyProblems.Solutions.Problem2058;

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
    private List<int> _points = default!;

    private void Traverse(ListNode prev, ListNode curr, int pos)
    {
        if (curr.next == null) return;

        var next = curr.next;

        if ((prev.val > curr.val && next.val > curr.val)
            || (prev.val < curr.val && next.val < curr.val)
           )
            _points.Add(pos);

        Traverse(curr, next, pos + 1);
    }

    public int[] NodesBetweenCriticalPoints(ListNode head)
    {
        _points = new List<int>();

        Traverse(head, head.next, 1);

        if (_points.Count < 2) return new[] { -1, -1 };

        var minDist = int.MaxValue;
        var maxDist = _points.Last() - _points.First();

        for (var i = 1; i < _points.Count; ++i) minDist = Math.Min(_points[i] - _points[i - 1], minDist);

        return new[] { minDist, maxDist };
    }
}