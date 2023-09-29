class Program
{
    private static void Main(string[] args)
    {
        var setA = new List<int> { 1, 2 };
        var setB = new List<string> { "a", "b" };

        // Task 1: Basic Cartesian Product
        var basicCartesianProduct = Cartesian_Product_and_Relations.CartesianProduct(setA, setB);
        Console.WriteLine("Task 1: Basic Cartesian Product");
        Cartesian_Product_and_Relations.PrintPairs(basicCartesianProduct);
        Console.WriteLine();

        // Task 2: Relation Testing and Advanced Operations
        var relation = new List<Tuple<int, string>> { Tuple.Create(1, "a"), Tuple.Create(2, "b") };
        var isRelationValidResult = Cartesian_Product_and_Relations.IsRelationValid(relation, setA, setB);
        Console.WriteLine("\nTask 2: Relation Validation");
        Console.WriteLine("Is Relation Valid: " + isRelationValidResult);

        var setC = new List<int> { 1, 2, 3, 4, 6 };
        var divisibleRelations = Cartesian_Product_and_Relations.FindRelations(setC, Cartesian_Product_and_Relations.IsDivisible);
        Console.WriteLine("\nTask 2: Finding Relations (Divisibility)");
        Cartesian_Product_and_Relations.PrintPairs(divisibleRelations);

        Console.WriteLine();

        // Task 3: Advanced Cartesian Product with Filters
        var setD = new List<int> { 1, 2, 3 };
        var setE = new List<int> { 3, 4, 5 };

        var filteredCartesianProductResult = Cartesian_Product_and_Relations.FilteredCartesianProduct(setD, setE, (a, b) => a < b);
        Console.WriteLine("\nTask 3: Filtered Cartesian Product (a < b)");
        Cartesian_Product_and_Relations.PrintPairs(filteredCartesianProductResult);

        Console.WriteLine("\n\n\n");
    }
}