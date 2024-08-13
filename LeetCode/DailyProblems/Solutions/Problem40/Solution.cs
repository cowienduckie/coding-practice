namespace DailyProblems.Solutions.Problem40;

public class Solution
{
    private List<IList<int>> _ans = null!;
    private int[] _arr = null!;
    private List<int> _combination = null!;
    private int _target;

    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        _arr = candidates;
        _target = target;
        _ans = new List<IList<int>>();
        _combination = new List<int>();

        Array.Sort(_arr);
        FindCombinations(0, 0);

        return _ans;
    }

    private void FindCombinations(int start, int sum)
    {
        if (sum == _target)
        {
            _ans.Add(new List<int>(_combination));
            return;
        }

        if (sum > _target)
        {
            return;
        }

        for (var i = start; i < _arr.Length; i++)
        {
            if (i > start && _arr[i] == _arr[i - 1])
            {
                continue;
            }

            _combination.Add(_arr[i]);

            FindCombinations(i + 1, sum + _arr[i]);

            _combination.RemoveAt(_combination.Count - 1);
        }
    }
}