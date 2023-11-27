namespace Laboratory
{
    // not mine
    class Program
    {
        static void Main(string[] args)
        {
            // task 1
            var x = 4;
            var b = 3; 
            var m = 2;
            Console.WriteLine($"For f(x) = mx + b, where x = {x}, b = {b} and m = {m}, the result is {Math.LinearFunction(x, b, m)}");

            Console.WriteLine();
            // task 2
            var set = new Set(new[] { (1, 2), (3, 6), (4, 8) });
            Console.WriteLine($"For set {set}, the domain is {set.GetDomain()} and the range is {set.GetRange()}");

            Console.WriteLine();
            // task 3
            set.ReplaceElements(new[] { (-1, 1), (0, 0), (1, 1) });
            Console.WriteLine($"Set of ordered pairs {set} is {set.CheckParity()}");

            Console.WriteLine();
            // task 4
            set.ReplaceElements(new[] { (2, 4), (3, 6), (4, 8) });
            Console.WriteLine($"Set of ordered pairs {set} is injective => {set.IsInjective()}");

            Console.WriteLine();
            // task 5
            set.ReplaceElements(new[] { (1, 2), (2, 3), (3, 4) });
            var codomain = new Set(new[] { 2, 3, 4 });
            Console.WriteLine($"Set of ordered pairs {set} is surjective => {set.IsSurjective(codomain)}");

            Console.WriteLine();
            // task 6
            var F = (double x) => x * x;
            var G = (double x) => 2 * x + 1;
            var operation = Math.Operation.Addition;
            x = 3;
            var result = Math.FunctionCombiner(F, G, operation, x);
            Console.WriteLine($"By adding function f(x) and g(x), where f(x) = x^2 and g(x) = 2x + 1, for value of x = {x}, we get {result}");

            Console.WriteLine();
            // task 7
            var points = new (double, double)[] { (-2, -4), (-1, -1), (0, 2), (1, 1), (2, 4) };

            var graphInfo = Math.GraphInformationExtractor(points);
            Console.WriteLine($"From points {points} we get:");
            Console.WriteLine(graphInfo);
        }
    }
}