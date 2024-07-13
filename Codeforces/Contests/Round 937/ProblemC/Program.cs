namespace ProblemC;

internal static class Program
{
    private static void Solve()
    {
        var input = Console.ReadLine()!.Split(':').Select(int.Parse).ToArray();
        var hours = input[0];
        var minutes = input[1];

        var isMorning = hours < 12;

        switch (hours)
        {
            case 0:
                hours = 12;
                break;
            case > 12:
                hours -= 12;
                break;
        }

        Console.WriteLine($"{hours:00}:{minutes:00} {(isMorning ? "AM" : "PM")}");
    }

    internal static void Main(string[] _)
    {
        var testCases = int.Parse(Console.ReadLine()!);

        while (testCases-- > 0) Solve();
    }
}