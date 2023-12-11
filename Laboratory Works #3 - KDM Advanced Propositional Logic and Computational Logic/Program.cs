public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Task 1 (Complex Logical Expressions Evaluation):");

        string expression = "A OR B AND (NOT C)";
        Dictionary<string, bool> dictionary = new()
        {
            { "A", true },
            { "B", false },
            { "C", true }
        };

        Console.WriteLine(Logic_Evaluator.ExpressionEvaluation(expression, dictionary) + "\n");

        Console.WriteLine("Task 2: Automated Truth Table Generation:" + "\n");

        Console.WriteLine(Logic_Evaluator.TruthTable(expression));
    }
}