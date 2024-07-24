using System.Text;

namespace DailyProblems.Solutions.Problem2191;

public class Solution
{
    public int[] SortJumbled(int[] mapping, int[] nums)
    {
        var mappingDict = mapping
            .Select((value, index) => new
            {
                Key = Convert.ToChar(index.ToString()),
                Value = Convert.ToChar(value.ToString())
            })
            .ToDictionary(x => x.Key, x => x.Value);

        return nums
            .Select(x => new Number(x, mappingDict))
            .OrderBy(x => x.MappedValue)
            .Select(x => x.Value)
            .ToArray();
    }

    private class Number
    {
        public int Value { get; }
        public int MappedValue { get; }

        public Number (int value, Dictionary<char, char> mapping)
        {
            Value = value;
            MappedValue = MapValue(mapping);
        }

        private int MapValue(Dictionary<char, char> mapping)
        {
            var builder = new StringBuilder();

            foreach (var digit in Value.ToString())
            {
                builder.Append(mapping[digit]);
            }

            return int.Parse(builder.ToString());
        }
    }
}