using NCalc; // library that helps us evaluate the booleans (NuGet Package: NCalc by Sebastien Ros)
using System.Text.RegularExpressions;


public static class Logic_Evaluator
{
    /// <summary>
    /// Since we can't parse the Dictionary to our Truth Table function, I use buffer Dictionary that grabs from Expression Eval.
    /// </summary>
    private static Dictionary<string, bool>? bufferDictionaryTruthTable;

    /// <summary>
    /// Function that grabs an expression and values from Dictionary and at the end returns the boolean from the expression.
    /// </summary>
    public static bool ExpressionEvaluation(string expression, Dictionary<string, bool> values)
    {
        var expressionCalc = new Expression(ReplaceLogicalOperators(expression));
        foreach (var kvp in values)
        {
            string key = kvp.Key;
            bool value = kvp.Value;
            expressionCalc.Parameters[key] = value;
        }
        bufferDictionaryTruthTable = values;
        return (bool)expressionCalc.Evaluate();
    }

    /// <summary>
    /// A function that converts AND OR NOT XOR to C# boolean operations. 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string ReplaceLogicalOperators(string input)
    {
        input = Regex.Replace(input, @"\bAND\b", "&&", RegexOptions.IgnoreCase);
        input = Regex.Replace(input, @"\bOR\b", "||", RegexOptions.IgnoreCase);
        input = Regex.Replace(input, @"\bNOT\b", "!", RegexOptions.IgnoreCase);
        input = Regex.Replace(input, @"\bXOR\b", "^", RegexOptions.IgnoreCase);
        return input;
    }

    /// <summary>
    /// Function that returns the Truth Table from the expression, the amount of variables is unlimitless.
    /// </summary>
    public static string TruthTable(string expression)
    {
        if (bufferDictionaryTruthTable == null)
        {
            return "Please define ExpressionEvaluation() and parse the dictionary to it!";
        }
        string result = "";

        bool first = true;
        foreach (var key in bufferDictionaryTruthTable.Keys)
        {
            string part = " " + key;

            while (part.Length < (first ? 6 : 7))
            {
                part += " ";
            }

            result += part + "|";
            first = false;
        }
        result += " " + expression + "\n";
        int len = result.Length;
        for (int i = 0; i < len - 1; i++)
        {
            result += "-";
        }
        result += "\n";

        List<string> values = new List<string>();
        GenerateTruthTableRecursive(values, 0, bufferDictionaryTruthTable.Count, "");

        foreach (var value in values)
        {
            string[] bVals = value.Split(' ');
            int i = 0;

            foreach (var key in bufferDictionaryTruthTable.Keys)
            {
                bufferDictionaryTruthTable[key] = bool.Parse(bVals[i++]);
            }
            result += value.Replace("true", "true  |").Replace("false", "false |") + " " + ExpressionEvaluation(expression, bufferDictionaryTruthTable).ToString().ToLower();
            result += "\n";
        }
        return result;
    }

    /// <summary>
    /// Recursively adds to our table default values from truth table.
    /// </summary>
    private static void GenerateTruthTableRecursive(List<string> truthTable, int index, int length, string tempValue)
    {
        if (index == length)
        {
            truthTable.Add(tempValue);
            return;
        }
        if (index == 0)
        {
            GenerateTruthTableRecursive(truthTable, 1, length, "true");
            GenerateTruthTableRecursive(truthTable, 1, length, "false");
            return;
        }

        GenerateTruthTableRecursive(truthTable, index + 1, length, tempValue + " true");
        GenerateTruthTableRecursive(truthTable, index + 1, length, tempValue + " false");

    }
}