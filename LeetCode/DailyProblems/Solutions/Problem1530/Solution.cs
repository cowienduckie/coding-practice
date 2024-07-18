namespace DailyProblems.Solutions.Problem1530;

public class Solution
{
    private static int _pairCount;
    private static int _distance;

    public int CountPairs(TreeNode root, int distance)
    {
        _pairCount = 0;
        _distance = distance;

        Traverse(root);

        return _pairCount;
    }

    private static int[] Traverse(TreeNode? node)
    {
        if (node == null)
        {
            return Array.Empty<int>();
        }

        if (node.left == null && node.right == null)
        {
            return new[] { 1 };
        }

        var leftDist = Traverse(node.left);
        var rightDist = Traverse(node.right);

        foreach (var left in leftDist)
        {
            foreach (var right in rightDist)
            {
                if (left + right <= _distance)
                {
                    ++_pairCount;
                }
            }
        }

        return leftDist
            .Concat(rightDist)
            .Where(x => x < _distance - 1)
            .Select(x => x + 1)
            .ToArray();
    }
}