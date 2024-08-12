namespace DailyProblems.Solutions.Problem703;

public class KthLargest
{
    private readonly int _k;
    private readonly List<int> _numsList;

    public KthLargest(int k, int[] nums)
    {
        _k = k;
        _numsList = new List<int>(nums);
        _numsList.Sort();
    }

    public int Add(int val)
    {
        var index = _numsList.BinarySearch(val);

        if (index < 0)
        {
            index = ~index;
        }

        _numsList.Insert(index, val);

        return _numsList[^_k];
    }
}