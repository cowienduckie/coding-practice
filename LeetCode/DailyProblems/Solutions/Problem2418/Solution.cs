namespace DailyProblems.Solutions.Problem2418;

public class Solution
{
    public string[] SortPeople(string[] names, int[] heights)
    {
        var people = new List<Person>();

        for (var i = 0; i < names.Length; ++i)
        {
            people.Add(new Person(names[i], heights[i]));
        }

        return people.OrderByDescending(p => p.Height)
                     .Select(p => p.Name)
                     .ToArray();
    }

    private record Person(string Name, int Height);
}