namespace DailyProblems.Solutions.Problem885;

public class Solution
{
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
    {
        var ans = new List<int[]>();
        var r = rStart;
        var c = cStart;
        var dir = Direction.Right;
        var visited = 0;
        var step = 1;
        var len = 2;

        while (visited < rows * cols)
        {
            for (var i = 1; i < len; ++i)
            {
                if (r >= 0 && r < rows && c >= 0 && c < cols)
                {
                    ans.Add(new[] { r, c });
                    ++visited;
                }

                Move(ref r, ref c, dir);
            }

            dir = SwitchDirection(dir);
            len = step % 2 == 0 ? len + 1 : len;
            ++step;
        }

        return ans.ToArray();
    }

    private static void Move(ref int r, ref int c, Direction dir)
    {
        switch(dir)
        {
            case Direction.Up:
                --r;
                break;
            case Direction.Right:
                ++c;
                break;
            case Direction.Down:
                ++r;
                break;
            case Direction.Left:
                --c;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
        }
    }

    private static Direction SwitchDirection(Direction dir)
    {
        return dir switch
        {
            Direction.Up => Direction.Right,
            Direction.Right => Direction.Down,
            Direction.Down => Direction.Left,
            Direction.Left => Direction.Up,
            _ => throw new ArgumentOutOfRangeException(nameof(dir), dir, null)
        };
    }

    private enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}