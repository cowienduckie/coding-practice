namespace ProblemA;

internal static class Program
{
    private static int Gcd(int a, int b)
    {
        return b == 0 ? a : Gcd(b, a % b);
    }

    private static void Solve()
    {
        var num = int.Parse(Console.ReadLine()!);
        var maxSum = 0;
        var result = 0;

        for (var i = 1; i < num; ++i)
        {
            var sum = Gcd(i, num) + i;

            if (sum > maxSum)
            {
                maxSum = sum;
                result = i;
            }
        }

        Console.WriteLine(result);
    }

    internal static void Main(string[] _)
    {
        var testCases = int.Parse(Console.ReadLine()!);

        while (testCases-- > 0) Solve();
    }
}