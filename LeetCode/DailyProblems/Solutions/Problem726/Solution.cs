namespace DailyProblems.Solutions.Problem726;

public class Solution
{
    public string CountOfAtoms(string formula)
    {
        var stack = new Stack<char>();
        var queue = new Queue<char>(formula);

        while(queue.Count > 0)
        {
            var chr = queue.Dequeue();

            if (chr == ')')
            {
                // Take the child formula and its multiplier
                var childFormula = string.Empty;
                var count = string.Empty;

                while (queue.Count > 0 && char.IsDigit(queue.Peek()))
                {
                    count += queue.Dequeue();
                }

                while (stack.Peek() != '(')
                {
                    childFormula = stack.Pop() + childFormula;
                }

                stack.Pop(); // Remove '('

                // Insert the group formula into the stack groupCount times
                var multiplier = count.Length > 0 ? int.Parse(count) : 1;
                var multipliedFormula = ConvertAtomFormulaWithoutParentheses(childFormula, multiplier);

                foreach (var c in multipliedFormula)
                {
                    stack.Push(c);
                }
            }
            else
            {
                stack.Push(chr);
            }
        }

        // After remove all parentheses, count the atoms in the final formula
        var finalFormula = new string(stack.Reverse().ToArray());

        return ConvertAtomFormulaWithoutParentheses(finalFormula);
    }

    private static SortedDictionary<string, int> CountOnFormulaWithoutParentheses(string formula, int multiplier = 1)
    {
        var atomDict = new SortedDictionary<string, int>();

        var atom = string.Empty;
        var count = string.Empty;

        foreach (var chr in formula)
        {
            if (char.IsUpper(chr))
            {
                if (atom.Length > 0)
                {
                    AddAtomToDict(ref atomDict, ref atom, ref count, multiplier);
                }

                atom += chr;
            }
            else if (char.IsLower(chr))
            {
                atom += chr;
            }
            else if (char.IsDigit(chr))
            {
                count += chr;
            }
        }

        AddAtomToDict(ref atomDict, ref atom, ref count, multiplier);

        return atomDict;
    }

    private static void AddAtomToDict(ref SortedDictionary<string, int> atomDict, ref string atom, ref string count, int multiplier)
    {
        if (count.Length == 0)
        {
            count = "1";
        }

        if (atomDict.ContainsKey(atom))
        {
            atomDict[atom] += int.Parse(count) * multiplier;
        }
        else
        {
            atomDict[atom] = int.Parse(count) * multiplier;
        }

        atom = string.Empty;
        count = string.Empty;
    }

    private static string ConvertAtomFormulaWithoutParentheses(string formula, int multiplier = 1)
    {
        var atomDict = CountOnFormulaWithoutParentheses(formula, multiplier);
        var result = string.Empty;

        foreach (var (atom, count) in atomDict)
        {
            result += $"{atom}{(count > 1 ? count : string.Empty)}";
        }

        return result;
    }
}