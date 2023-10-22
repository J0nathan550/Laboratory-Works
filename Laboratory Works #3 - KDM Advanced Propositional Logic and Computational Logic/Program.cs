public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Task 1 (Complex Logical Expressions Evaluation):");

        string expression = "(A AND B) OR (NOT C)";
        Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
        dictionary.Add("A", true);
        dictionary.Add("B", false);
        dictionary.Add("C", true);

        Console.WriteLine(Logic_Evaluator.ExpressionEvaluation(expression, dictionary) + "\n");

        Console.WriteLine("Task 2: Automated Truth Table Generation:" + "\n");

        Console.WriteLine(Logic_Evaluator.TruthTable(expression));
    }
}