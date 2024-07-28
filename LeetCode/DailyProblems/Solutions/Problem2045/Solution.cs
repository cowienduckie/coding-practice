namespace DailyProblems.Solutions.Problem2045;

public class Solution
{
    public int SecondMinimum(int n, int[][] edges, int time, int change)
    {
        // Add all nodes and their neighbors to dictionary
        var dict = new Dictionary<int, Node>();

        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];

            if (!dict.ContainsKey(u))
            {
                dict[u] = new Node();
            }

            if (!dict.ContainsKey(v))
            {
                dict[v] = new Node();
            }

            dict[u].Neighbors.Add(dict[v]);
            dict[v].Neighbors.Add(dict[u]);
        }

        // BFS to find the first and second time meet n-th node
        var queue = new Queue<(Node, int)>();

        queue.Enqueue((dict[1], 0));

        while (queue.Count != 0)
        {
            var (currNode , currTime) = queue.Dequeue();

            if (currNode.IsFirstMet)
            {
                currNode.FirstMet = currTime;
            }
            else if (currNode.IsSecondMet && currNode.FirstMet != currTime)
            {
                currNode.SecondMet = currTime;
            }
            else
            {
                continue;
            }

            foreach (var neighbor in currNode.Neighbors)
            {
                var isRedLight = currTime / change % 2 == 1;
                var stopTime = 0;

                if (isRedLight)
                {
                    stopTime = change - currTime % change;
                }

                queue.Enqueue((neighbor, currTime + time + stopTime));
            }
        }

        return dict[n].SecondMet;
    }

    private class Node
    {
        public List<Node> Neighbors { get; } = new();
        public int FirstMet { get; set; } = -1;
        public int SecondMet { get; set; } = -1;
        public bool IsFirstMet => FirstMet == -1;
        public bool IsSecondMet => SecondMet == -1;
    }
}