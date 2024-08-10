namespace DailyProblems.Solutions.Problem959;

public class Solution
{
    public int RegionsBySlashes(string[] grid)
    {
        var rows = grid.Length * 3;
        var cols = grid[0].Length * 3;

        var mat = new int[rows][];
        var group = new int[rows][];

        for (var r = 0; r < rows; ++r)
        {
            mat[r] = new int[cols];
            group[r] = new int[cols];
        }

        for (var i = 0; i < grid.Length; ++i)
        {
            for (var j = 0; j < grid[i].Length; ++j)
            {
                switch (grid[i][j])
                {
                    case '/':
                        mat[i * 3][j * 3 + 2] = 1;
                        mat[i * 3 + 1][j * 3 + 1] = 1;
                        mat[i * 3 + 2][j * 3] = 1;
                        break;

                    case '\\':
                        mat[i * 3][j * 3] = 1;
                        mat[i * 3 + 1][j * 3 + 1] = 1;
                        mat[i * 3 + 2][j * 3 + 2] = 1;
                        break;
                }
            }
        }

        var ans = 0;

        for (var r = 0; r < rows; ++r)
        {
            for (var c = 0; c < cols; ++c)
            {
                if (mat[r][c] != 0 || group[r][c] != 0)
                {
                    continue;
                }

                Dfs(mat, group, ++ans, r, c);
            }
        }

        return ans;
    }

    private static void Dfs(int[][] mat, int[][] group, int groupNum, int r, int c)
    {
        if (r < 0 || r >= mat.Length || c < 0 || c >= mat[0].Length
            || group[r][c] != 0
            || mat[r][c] == 1)
        {
            return;
        }

        group[r][c] = groupNum;

        Dfs(mat, group, groupNum, r - 1, c);
        Dfs(mat, group, groupNum, r + 1, c);
        Dfs(mat, group, groupNum, r, c - 1);
        Dfs(mat, group, groupNum, r, c + 1);
    }
}