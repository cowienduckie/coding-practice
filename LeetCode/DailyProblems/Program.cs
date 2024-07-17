namespace DailyProblems;

internal static class Program
{
    internal static void Main(string[] _)
    {
        var solution = new Solutions.Problem1110.Solution();

        var root = new Solutions.Problem1110.TreeNode(1)
        {
            left = new Solutions.Problem1110.TreeNode(2)
            {
                left = new Solutions.Problem1110.TreeNode(4),
                right = new Solutions.Problem1110.TreeNode(5)
            },
            right = new Solutions.Problem1110.TreeNode(3)
            {
                left = new Solutions.Problem1110.TreeNode(6),
                right = new Solutions.Problem1110.TreeNode(7)
            }
        };

        var ans = solution.DelNodes(root, new []{ 3, 5 });

        foreach (var node in ans)
        {
            Console.WriteLine(node.val);
        }
    }
}