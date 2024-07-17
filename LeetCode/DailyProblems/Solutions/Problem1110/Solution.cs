namespace DailyProblems.Solutions.Problem1110;

public class Solution
{
    private static List<TreeNode> _ans = null!;
    private static HashSet<int> _toDelete = null!;

    private static bool IsEndDfs => _toDelete.Count == 0;

    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
    {
        _toDelete = new HashSet<int>(to_delete);
        _ans = new List<TreeNode>();

        if (!IsDelete(root))
        {
            _ans.Add(root);
        }

        Traverse(root);

        return _ans;
    }

    private static void Traverse(TreeNode? node)
    {
        if (node == null)
        {
            return;
        }

        if (IsDelete(node))
        {
            if (IsNewRoot(node.left))
            {
                _ans.Add(node.left!);
            }

            if (IsNewRoot(node.right))
            {
                _ans.Add(node.right!);
            }
        }

        if (IsEndDfs)
        {
            return;
        }

        Traverse(node.left);
        Traverse(node.right);

        if (IsDelete(node.left))
        {
            _toDelete.Remove(node.left!.val);
            node.left = null;
        }

        if (IsDelete(node.right))
        {
            _toDelete.Remove(node.right!.val);
            node.right = null;
        }
    }

    private static bool IsDelete(TreeNode? node)
    {
        return node != null && _toDelete.Contains(node.val);
    }

    private static bool IsNewRoot(TreeNode? node)
    {
        return node != null && !_toDelete.Contains(node.val);
    }
}