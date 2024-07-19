namespace DailyProblems.Solutions.Problem1380;

public class Solution
{
    public IList<int> LuckyNumbers (int[][] matrix)
    {
        var rowNum = matrix.Length;
        var colNum = matrix[0].Length;

        var colMax = new int[colNum];
        var rowMin = new int[rowNum];

        Array.Fill(colMax, int.MinValue);
        Array.Fill(rowMin, int.MaxValue);

        for (var i = 0; i < rowNum; ++i)
        {
            for (var j = 0; j < colNum; ++j)
            {
                colMax[j] = Math.Max(colMax[j], matrix[i][j]);
                rowMin[i] = Math.Min(rowMin[i], matrix[i][j]);
            }
        }

        return colMax.Intersect(rowMin).ToList();
    }
}