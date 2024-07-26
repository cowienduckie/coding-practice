namespace DailyProblems.Solutions.Problem1334;

public class SolutionDfs
{
    public int FindTheCity(int n, int[][] edges, int distanceThreshold)
    {
        var nodes = new Dictionary<int, Node>();

        for (int i = 0; i < n; i++)
        {
            nodes[i] = new Node(i);
        }

        foreach (var edge in edges)
        {
            var from = edge[0];
            var to = edge[1];
            var weight = edge[2];

            nodes[from].Neighbors.Add((nodes[to], weight));
            nodes[to].Neighbors.Add((nodes[from], weight));
        }

        var minCityCount = int.MaxValue;
        var ans = int.MinValue;

        foreach (var node in nodes.Values)
        {
            var visited = new HashSet<int>();
            var queue = new Queue<(Node, int)>();

            queue.Enqueue((node, 0));

            while (queue.Count > 0)
            {
                var (currentNode, currentWeight) = queue.Dequeue();

                visited.Add(currentNode.Value);

                foreach (var (neighbor, neighborWeight) in currentNode.Neighbors)
                {
                    if (currentWeight + neighborWeight > distanceThreshold || visited.Contains(neighbor.Value))
                    {
                        continue;
                    }

                    queue.Enqueue((neighbor, currentWeight + neighborWeight));
                }
            }

            if (visited.Count < minCityCount)
            {
                minCityCount = visited.Count;
                ans = node.Value;
            }
            else if (visited.Count == minCityCount)
            {
                ans = Math.Max(ans, node.Value);
            }
        }

        return ans;
    }

    private class Node
    {
        public int Value { get; }
        public List<(Node, int)> Neighbors { get; }

        public Node(int value)
        {
            Value = value;
            Neighbors = new List<(Node, int)>();
        }
    }
}