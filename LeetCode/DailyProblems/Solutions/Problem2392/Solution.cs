namespace DailyProblems.Solutions.Problem2392;

public class Solution
{
    public int[][] BuildMatrix(int k, int[][] rowConditions, int[][] colConditions)
    {
        // Find the positions of the numbers in the matrix
        if (!FindPositions(rowConditions, k, out var rowPositions))
        {
            return Array.Empty<int[]>();
        }

        if (!FindPositions(colConditions, k, out var colPositions))
        {
            return Array.Empty<int[]>();
        }

        // Initialize the matrix
        var matrix = new int[k][];

        for (var i = 0; i < k; ++i)
        {
            matrix[i] = new int[k];
        }

        // Fill the matrix
        for (var i = 1; i <= k; ++i)
        {
            matrix[rowPositions[i]][colPositions[i]] = i;
        }

        return matrix;
    }

    private static bool FindPositions(int[][] conditions, int matrixSize, out int[] positions)
    {
        // Construct a graph from the conditions
        var nodes = new Dictionary<int, Node>();

        foreach (var condition in conditions)
        {
            var parent = condition[0];
            var child = condition[1];

            if (!nodes.ContainsKey(parent))
            {
                nodes[parent] = new Node(parent);
            }

            if (!nodes.ContainsKey(child))
            {
                nodes[child] = new Node(child);
            }

            nodes[child].Parents.Add(nodes[parent]);
            nodes[parent].Children.Add(nodes[child]);
        }

        // Push the values with no condition to the path
        // Push the nodes with no parent to the queue
        var path = new HashSet<int>();
        var queue = new Queue<Node>();

        for (var i = 1; i <= matrixSize; i++)
        {
            if (!nodes.ContainsKey(i))
            {
                path.Add(i);
                continue;
            }

            if (!nodes[i].Parents.Any())
            {
                queue.Enqueue(nodes[i]);
            }
        }

        // Traverse the graph
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (!path.Add(node.Value))
            {
                // Cycle detected, return false
                positions = Array.Empty<int>();

                return false;
            }

            foreach (var child in node.Children)
            {
                // Remove this node from the parents of the children
                child.Parents.Remove(node);

                // If the child has no parents, add it to the queue
                if (!child.Parents.Any())
                {
                    queue.Enqueue(child);
                }
            }
        }

        // Check if the path is complete
        if (path.Count != matrixSize)
        {
            positions = Array.Empty<int>();

            return false;
        }

        // Convert the path to and position array
        positions = new int[matrixSize + 1];

        var index = 0;

        foreach (var node in path)
        {
            positions[node] = index++;
        }

        return true;
    }

    private class Node
    {
        public int Value { get; }
        public List<Node> Parents { get; }
        public List<Node> Children { get; }

        public Node(int value)
        {
            Value = value;
            Children = new List<Node>();
            Parents = new List<Node>();
        }
    }
}