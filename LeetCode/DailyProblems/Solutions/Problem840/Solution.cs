namespace DailyProblems.Solutions.Problem840;

public class Solution
{
    public int NumMagicSquaresInside(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;

        if (rows < 3 || cols < 3)
        {
            return 0;
        }

        var ans = 0;

        for (var r = 0; r < rows - 2; ++r)
        {
            for (var c = 0; c < cols - 2; ++c)
            {
                if (IsMagicSquare(grid, r, c))
                {
                    ++ans;
                }
            }
        }

        return ans;
    }

    private static bool IsMagicSquare(int[][] grid, int r, int c)
    {
        var distinctCells = new HashSet<int>();

        for (var i = r; i < r + 3; ++i)
        {
            var colSum = 0;
            var rowSum = 0;

            for (var j = c; j < c + 3; ++j)
            {
                rowSum += grid[i][j];
                colSum += grid[r - c + j][c - r + i];

                if (grid[i][j] > 9 || !distinctCells.Add(grid[i][j]))
                {
                    return false;
                }
            }

            if (colSum != 15 || rowSum != 15)
            {
                return false;
            }
        }

        return grid[r][c] + grid[r + 1][c + 1] + grid[r + 2][c + 2] == 15
            && grid[r][c + 2] + grid[r + 1][c + 1] + grid[r + 2][c] == 15;
    }
}