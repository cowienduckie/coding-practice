using System.Text;

namespace DailyProblems.Solutions.Problem2096;

public class SolutionDfs
{
    private static int _startValue;
    private static int _destValue;

    private static List<char> _startPath = null!;
    private static List<char> _destPath = null!;

    private static bool IsEndDfs => _startPath.Any() && _destPath.Any();

    public string GetDirections(TreeNode root, int startValue, int destValue)
    {
        _startValue = startValue;
        _destValue = destValue;

        _startPath = new List<char>();
        _destPath = new List<char>();

        // DFS to find path from root to startValue and destValue
        Traverse(root, new List<char>());

        // Remove the common path from startPath and destPath
        // Convert path to startValue full of Up moves
        // Keep the destValue path as is
        var commonPathLength = 0;

        while (commonPathLength < _startPath.Count
               && commonPathLength < _destPath.Count
               && _startPath[commonPathLength] == _destPath[commonPathLength])
        {
            commonPathLength++;
        }

        var resultPath = new StringBuilder();

        for (var i = commonPathLength; i < _startPath.Count; i++)
        {
            resultPath.Append(Move.Up);
        }

        for (var i = commonPathLength; i < _destPath.Count; i++)
        {
            resultPath.Append(_destPath[i]);
        }

        return resultPath.ToString();
    }

    private static bool Traverse(TreeNode? node, List<char> path)
    {
        if (node == null)
        {
            return false;
        }

        if (node.val == _startValue)
        {
            _startPath.AddRange(path);
        }
        else if (node.val == _destValue)
        {
            _destPath.AddRange(path);
        }

        if (IsEndDfs)
        {
            return true;
        }

        // Traverse left subtree
        path.Add(Move.Left);

        if (Traverse(node.left, path))
        {
            return true;
        }

        path.RemoveAt(path.Count - 1);

        // Traverse right subtree
        path.Add(Move.Right);

        if (Traverse(node.right, path))
        {
            return true;
        }

        path.RemoveAt(path.Count - 1);

        return false;
    }

    private static class Move
    {
        public const char Up = 'U';
        public const char Left = 'L';
        public const char Right = 'R';
    }
}