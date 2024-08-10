namespace DailyProblems;

internal static class Program
{
    internal static void Main(string[] _)
    {
        var solution = new Solutions.Problem840.Solution();

        //[[3,10,2,3,4],[4,5,6,8,1],[8,8,1,6,8],[1,3,5,7,1],[9,4,9,2,9]]
        var grid = new []
        {
            new []{ 3,10,2,3,4 },
            new []{ 4,5,6,8,1 },
            new []{ 8,8,1,6,8 },
            new []{ 1,3,5,7,1 },
            new []{ 9,4,9,2,9 }
        };

        var ans = solution.NumMagicSquaresInside(grid);

        Console.WriteLine(ans);
    }
}