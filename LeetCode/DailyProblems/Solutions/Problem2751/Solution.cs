namespace DailyProblems.Solutions.Problem2751;

public class Solution
{
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
    {
        var robots = Enumerable.Range(0, positions.Length)
            .Select(i => new Robot(i, positions[i], healths[i], directions[i]))
            .OrderBy(r => r.Position)
            .ToList();

        var stack = new Stack<Robot>();

        foreach (var robot in robots)
        {
            var nextRobot = robot;

            while (stack.Count > 0
                   && stack.Peek().Direction == Direction.Right
                   && nextRobot.Direction == Direction.Left
                   && nextRobot.IsAlive())
            {
                var stackRobot = stack.Pop();

                RobotFight(ref nextRobot , ref stackRobot);

                if (stackRobot.IsAlive())
                {
                    stack.Push(stackRobot);
                }
            }

            if (nextRobot.IsAlive())
            {
                stack.Push(nextRobot);
            }
        }

        return stack
            .OrderBy(r => r.Id)
            .Select(r => r.Health)
            .ToList();
    }

    private static void RobotFight(ref Robot leftRobot, ref Robot rightRobot)
    {
        if (leftRobot.Health > rightRobot.Health)
        {
            leftRobot.LoseHealth();
            rightRobot.Die();
        }
        else if (leftRobot.Health < rightRobot.Health)
        {
            leftRobot.Die();
            rightRobot.LoseHealth();
        }
        else
        {
            leftRobot.Die();
            rightRobot.Die();
        }
    }

    private enum Direction
    {
        Left,
        Right
    }

    private class Robot
    {
        public int Id { get; }
        public int Position { get; }
        public int Health { get; private set; }
        public Direction Direction { get; }

        public Robot(int id, int position, int health, char direction)
        {
            Id = id;
            Position = position;
            Health = health;
            Direction = direction == 'L' ? Direction.Left : Direction.Right;
        }

        public void LoseHealth()
        {
            Health -= 1;
        }

        public void Die()
        {
            Health = 0;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}