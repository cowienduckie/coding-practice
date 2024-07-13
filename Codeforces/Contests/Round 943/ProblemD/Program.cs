namespace ProblemD;

internal static class Program
{
    private static int[] _adj = null!;
    private static ulong[] _points = null!;
    private static bool[] _visited = null!;

    private static ulong Traverse(int curr, uint turnLeft)
    {
        if (turnLeft == 0) return 0;

        if (_visited[_adj[curr]])
            // End of the path
            return _points[curr] * turnLeft;

        _visited[curr] = true;

        var keepTraverse = _points[curr] + Traverse(_adj[curr], turnLeft - 1);
        var stopTraverse = _points[curr] * turnLeft;

        _visited[curr] = false;

        return Math.Max(keepTraverse, stopTraverse);
    }

    private static void Solve()
    {
        var input = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
        var num = input[0];
        var totalTurns = (uint)input[1];
        var bStart = input[2] - 1;
        var sStart = input[3] - 1;

        _adj = Console.ReadLine()!.Split(' ').Select(x => int.Parse(x) - 1).ToArray();
        _points = Console.ReadLine()!.Split(' ').Select(ulong.Parse).ToArray();

        _visited = Enumerable.Repeat(false, num).ToArray();

        var bPoint = Traverse(bStart, totalTurns);
        var sPoint = Traverse(sStart, totalTurns);

        if (bPoint > sPoint)
            Console.WriteLine("Bodya");
        else if (bPoint < sPoint)
            Console.WriteLine("Sasha");
        else
            Console.WriteLine("Draw");
    }

    internal static void Main(string[] _)
    {
        var testCases = int.Parse(Console.ReadLine()!);

        while (testCases-- > 0) Solve();
    }
}