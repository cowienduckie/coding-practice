using System.Text;

namespace ProblemD;

internal static class Program
{
    private static void Solve()
    {
        var totalInstructions = int.Parse(Console.ReadLine()!);
        var instructions = Console.ReadLine()!.ToCharArray();

        var maxLocation = new[] { 0, 0 };

        foreach (var instruction in instructions)
            switch (instruction)
            {
                case 'N':
                    maxLocation[1]++;
                    break;
                case 'S':
                    maxLocation[1]--;
                    break;
                case 'W':
                    maxLocation[0]--;
                    break;
                case 'E':
                    maxLocation[0]++;
                    break;
            }

        if (maxLocation[0] % 2 != 0 || maxLocation[1] % 2 != 0)
        {
            Console.WriteLine("NO");
            return;
        }

        var finalLocation = new[] { maxLocation[0] / 2, maxLocation[1] / 2 };

        var north = finalLocation[1] > 0 ? finalLocation[1] : 0;
        var south = finalLocation[1] < 0 ? -finalLocation[1] : 0;
        var east = finalLocation[0] > 0 ? finalLocation[0] : 0;
        var west = finalLocation[0] < 0 ? -finalLocation[0] : 0;

        if (north == 0 && south == 0 && east == 0 && west == 0)
            switch (instructions[0])
            {
                case 'N':
                case 'S':
                    ++north;
                    ++south;
                    break;
                case 'W':
                case 'E':
                    ++east;
                    ++west;
                    break;
            }

        var result = new StringBuilder();

        foreach (var instruction in instructions)
            switch (instruction)
            {
                case 'N':
                    result.Append(north > 0 ? 'R' : 'H');
                    north--;
                    break;
                case 'S':
                    result.Append(south > 0 ? 'R' : 'H');
                    south--;
                    break;
                case 'W':
                    result.Append(west > 0 ? 'R' : 'H');
                    west--;
                    break;
                case 'E':
                    result.Append(east > 0 ? 'R' : 'H');
                    east--;
                    break;
            }

        if (result.ToString().Any(c => c == 'H'))
            Console.WriteLine(result);
        else
            Console.WriteLine("NO");
    }

    internal static void Main(string[] _)
    {
        var testCases = int.Parse(Console.ReadLine()!);

        while (testCases-- > 0) Solve();
    }
}