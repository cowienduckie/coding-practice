namespace DailyProblems.Solutions.Problem1334;

public class SolutionFloydWarshall
{
    public int FindTheCity(int n, int[][] edges, int distanceThreshold)
    {
        // Initialize cost matrix
        var cost = new int[n][];

        for (var i = 0; i < n; i++)
        {
            cost[i] = new int[n];

            for (var j = 0; j < n; j++)
            {
                cost[i][j] = i == j ? 0 : int.MaxValue;
            }
        }

        // Update cost matrix with edge weights
        foreach (var edge in edges)
        {
            var from = edge[0];
            var to = edge[1];
            var weight = edge[2];

            cost[from][to] = weight;
            cost[to][from] = weight;
        }

        // Floyd-Warshall algorithm
        // Update cost from i to j through k
        for (var k = 0; k < n; ++k)
        {
            for (var i = 0; i < n; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    if (cost[i][k] != int.MaxValue && cost[k][j] != int.MaxValue)
                    {
                        cost[i][j] = Math.Min(cost[i][j], cost[i][k] + cost[k][j]);
                    }
                }
            }
        }

        // Find the city with the minimum number of reachable cities
        var minCityCount = int.MaxValue;
        var ans = int.MinValue;

        for (var i = 0; i < n; i++)
        {
            var cityCount = 0;

            for (var j = 0; j < n; j++)
            {
                if (cost[i][j] <= distanceThreshold)
                {
                    ++cityCount;
                }
            }

            if (cityCount <= minCityCount)
            {
                minCityCount = cityCount;
                ans = i;
            }
        }

        return ans;
    }
}