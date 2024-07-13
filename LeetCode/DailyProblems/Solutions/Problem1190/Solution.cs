namespace DailyProblems.Solutions.Problem1190;

public class Solution
{
    public string ReverseParentheses(string s)
    {
        var charQueue = new Queue<char>(s);
        var tempQueue = new Queue<char>();
        var stack = new Stack<char>();

        while (charQueue.Count > 0)
        {
            var c = charQueue.Dequeue();

            if (c == ')')
            {
                while (stack.Peek() != '(') tempQueue.Enqueue(stack.Pop());

                stack.Pop();

                while (tempQueue.Count > 0) stack.Push(tempQueue.Dequeue());
            }
            else
            {
                stack.Push(c);
            }
        }

        var stackArr = stack.ToArray();

        return new string(stack.ToArray().Reverse().ToArray());
    }
}