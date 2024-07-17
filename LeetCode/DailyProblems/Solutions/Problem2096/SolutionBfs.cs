namespace DailyProblems.Solutions.Problem2096;

public class SolutionBfs
{
    public string GetDirections(TreeNode root, int startValue, int destValue)
    {
        var queue = new Queue<(TreeNode node, string path)>();

        queue.Enqueue((root, string.Empty));

        var startPath = string.Empty;
        var destPath = string.Empty;

        // BFS to find path from root to startValue and destValue
        while (queue.Count > 0)
        {
            var (node, path) = queue.Dequeue();

            if (node.val == startValue)
            {
                startPath = path;
            }
            else if (node.val == destValue)
            {
                destPath = path;
            }

            if (startPath != string.Empty && destPath != string.Empty)
            {
                break;
            }

            if (node.left != null)
            {
                queue.Enqueue((node.left, path + Move.Left));
            }

            if (node.right != null)
            {
                queue.Enqueue((node.right, path + Move.Right));
            }
        }

        // Remove the common path from startPath and destPath
        // Convert path to startValue full of Up moves
        // Keep the destValue path as is
        var startPathWithoutCommon = string.Empty;
        var destPathWithoutCommon = string.Empty;

        for (var i = 0; i < startPath.Length && i < destPath.Length; i++)
        {
            if (startPath[i] == destPath[i])
            {
                continue;
            }

            if (i < startPath.Length)
            {
                startPathWithoutCommon += Move.Up;
            }

            if (i < destPath.Length)
            {
                destPathWithoutCommon += destPath[i];
            }
        }

        return startPathWithoutCommon + destPathWithoutCommon;
    }

    private static class Move
    {
        public const char Up = 'U';
        public const char Left = 'L';
        public const char Right = 'R';
    }
}