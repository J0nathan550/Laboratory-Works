namespace Laboratory_Works__3___KDM_Advanced_Propositional_Logic_and_Computational_Logic
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Task 1 (Complex Logical Expressions Evaluation):");

            string expression = "(A AND B) OR (C AND D)";
            Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
            dictionary.Add("A", true);
            dictionary.Add("B", false);
            dictionary.Add("C", true);
            dictionary.Add("D", true);

            Console.WriteLine(Logic_Evaluator.ExpressionEvaluation(expression, dictionary) + "\n");

            Console.WriteLine("Task 2: Automated Truth Table Generation:" + "\n");

            Console.WriteLine(Logic_Evaluator.TruthTable(expression));
        }
    }
}