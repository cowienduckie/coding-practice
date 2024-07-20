namespace DailyProblems.Solutions.Problem1650;

public class Solution
{
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum)
    {
        var matrix = new int[rowSum.Length][];

        for (var i = 0; i < rowSum.Length; ++i)
        {
            matrix[i] = new int[colSum.Length];
        }

        for (var i = 0; i < rowSum.Length; ++i)
        {
            for (var j = 0; j < colSum.Length; ++j)
            {
                matrix[i][j] = Math.Min(rowSum[i], colSum[j]);
                rowSum[i] -= matrix[i][j];
                colSum[j] -= matrix[i][j];
            }
        }

        return matrix;
    }
}