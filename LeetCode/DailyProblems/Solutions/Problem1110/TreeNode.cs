using System.Diagnostics.CodeAnalysis;

namespace DailyProblems.Solutions.Problem1110;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class TreeNode
{
    public readonly int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
