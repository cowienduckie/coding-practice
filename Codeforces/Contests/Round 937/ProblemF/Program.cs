namespace ProblemF;

internal static class Program
{
    private static void Solve()
    {
        var input = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
        var twoChild = input[0];
        var oneChild = input[1];
        var leaf = input[2];

        if (twoChild == 0)
        {
            if (oneChild == 0)
                Console.WriteLine(leaf == 1 ? 0 : -1); // Case 0 0 1 or 0 0 x
            else
                Console.WriteLine(leaf == 1 ? oneChild : -1); // Case 0 x 1 or 0 x y

            return;
        }

        if (twoChild + 1 != leaf)
        {
            Console.WriteLine(-1);
            return;
        }

        var levelsWithTwoChild = (int)Math.Floor(Math.Log2(twoChild));
        var padding = (int)Math.Pow(2, levelsWithTwoChild + 1) - 1 - twoChild;

        if (oneChild <= padding)
        {
            Console.WriteLine(levelsWithTwoChild + 1);
        }
        else
        {
            var levelWithOneChild =
                (int)Math.Ceiling((oneChild - padding) / (Math.Pow(2, levelsWithTwoChild + 1) - padding));

            Console.WriteLine(levelsWithTwoChild + levelWithOneChild + 1);
        }
    }

    internal static void Main(string[] _)
    {
        var testCases = int.Parse(Console.ReadLine()!);

        while (testCases-- > 0) Solve();
    }
}