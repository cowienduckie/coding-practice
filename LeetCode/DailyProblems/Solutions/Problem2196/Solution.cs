namespace DailyProblems.Solutions.Problem2196;

public class TreeNode
{
    public TreeNode left;
    public TreeNode right;
    public int val;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public TreeNode CreateBinaryTree(int[][] descriptions)
    {
        var nodeDict = new Dictionary<int, NewTreeNode>();

        foreach (var desc in descriptions)
        {
            var parentValue = desc[0];
            var childValue = desc[1];
            var isLeft = desc[2] == 1;

            if (!nodeDict.ContainsKey(parentValue))
            {
                nodeDict[parentValue] = new NewTreeNode(parentValue);
            }

            if (!nodeDict.ContainsKey(childValue))
            {
                nodeDict[childValue] = new NewTreeNode(childValue);
            }

            if (isLeft)
            {
                nodeDict[parentValue].left = nodeDict[childValue];
            }
            else
            {
                nodeDict[parentValue].right = nodeDict[childValue];
            }

            nodeDict[childValue].hasParent = true;
        }

        foreach (var node in nodeDict.Values)
        {
            if (!node.hasParent)
            {
                return node;
            }
        }

        return null;
    }

    private class NewTreeNode : TreeNode
    {
        public bool hasParent { get; set; } = false;

        public NewTreeNode(int val = 0, NewTreeNode left = null, NewTreeNode right = null) : base(val, left, right)
        {
        }
    }
}