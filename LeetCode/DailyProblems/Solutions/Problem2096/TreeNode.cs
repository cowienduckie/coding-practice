using System.Diagnostics.CodeAnalysis;

namespace DailyProblems.Solutions.Problem2096;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class TreeNode
{
    public readonly int val;
    public readonly TreeNode? left;
    public readonly TreeNode? right;

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
