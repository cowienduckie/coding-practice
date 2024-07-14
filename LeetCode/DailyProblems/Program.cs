namespace DailyProblems;

internal static class Program
{
    internal static void Main(string[] _)
    {
        var solution = new Solutions.Problem726.Solution();

        var ans = solution.CountOfAtoms("Mg(H2O)N");

        Console.WriteLine(ans);
    }
}