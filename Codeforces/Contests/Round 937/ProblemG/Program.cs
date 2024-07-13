namespace ProblemG;

internal static class Program
{
    private static int _num;
    private static bool[,] _adjacent = default!;
    private static int[,] _dp = default!;

    private static int Dfs(int curr, int mask)
    {
        if (mask == (1 << _num) - 1) // Is all visited
            return 0;

        if (_dp[curr, mask] != -1) // Is already calculated
            return _dp[curr, mask];

        var result = 0; // Longest path from current node to the end

        for (var next = 0; next < _num; ++next)
            if ((mask & (1 << next)) == 0 && _adjacent[curr, next]) // Is not visited and is adjacent
                result = Math.Max(result, 1 + Dfs(next, mask | (1 << next)));

        return _dp[curr, mask] = result;
    }

    private static void Solve()
    {
        _num = int.Parse(Console.ReadLine()!);

        var genre = new string[_num];
        var writer = new string[_num];

        for (var i = 0; i < _num; ++i)
        {
            var input = Console.ReadLine()!.Split(' ');

            genre[i] = input[0];
            writer[i] = input[1];
        }

        _adjacent = new bool[_num, _num];

        for (var i = 0; i < _num; ++i)
        for (var j = i + 1; j < _num; ++j)
            if (genre[i] == genre[j] || writer[i] == writer[j])
            {
                _adjacent[i, j] = true;
                _adjacent[j, i] = true;
            }

        _dp = new int[_num, 1 << _num];

        for (var i = 0; i < _num; ++i)
        for (var j = 0; j < 1 << _num; ++j)
            _dp[i, j] = -1;

        var longestPath = 1;

        for (var i = 0; i < _num; ++i) longestPath = Math.Max(longestPath, 1 + Dfs(i, 1 << i));

        Console.WriteLine(_num - longestPath);
    }

    internal static void Main(string[] _)
    {
        var testCases = int.Parse(Console.ReadLine()!);

        while (testCases-- > 0) Solve();
    }
}