namespace DailyProblems.Solutions.Problem1568;

public class Solution
{
    private static int[][] _grid = null!;
    private static int Rows => _grid.Length;
    private static int Cols => _grid[0].Length;

    public int MinDays(int[][] grid)
    {
        _grid = grid;

        if (IsDisconnected())
        {
            return 0;
        }

        for (var r = 0; r < Rows; ++r)
        {
            for (var c = 0; c < Cols; ++c)
            {
                if (_grid[r][c] == 0)
                {
                    continue;
                }

                _grid[r][c] = 0;

                if (IsDisconnected())
                {
                    return 1;
                }

                _grid[r][c] = 1;
            }
        }

        return 2;
    }

    private static bool IsDisconnected()
    {
        var island = new int[Rows][];

        for (var i = 0; i < Rows; ++i)
        {
            island[i] = new int[Cols];
        }

        var hasIsland = false;

        for (var c = 0; c < Cols; ++c)
        {
            for (var r = 0; r < Rows; ++r)
            {
                if (_grid[r][c] == 0 || island[r][c] != 0)
                {
                    continue;
                }

                if (hasIsland)
                {
                    return true;
                }

                Dfs(island, c, r);

                hasIsland = true;
            }
        }

        return !hasIsland;
    }

    private static void Dfs(int[][] island, int c, int r)
    {
        if (r < 0 || r >= Rows || c < 0 || c >= Cols || _grid[r][c] == 0 || island[r][c] != 0)
        {
            return;
        }

        island[r][c] = 1;

        Dfs(island, c - 1, r);
        Dfs(island, c + 1, r);
        Dfs(island, c, r - 1);
        Dfs(island, c, r + 1);
    }
}