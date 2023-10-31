class Program
{
    private static void Main(string[] args)
    {
        string output = "";
        Console.WriteLine("Checking the result of uniting setA, setB\n");

        List<object> setA = new List<object>() { 2, 4, 6, 8, 10 };
        List<object> setB = new List<object>() { 1, 3, 5, 7, 9 };
        var anotherList = Set.Union(setA, setB);

        output = "{";
        foreach (var item in anotherList)
        {
            output += item.ToString() + ", ";
        }

        output = output.Substring(0, output.Length - 2);
        output += "}";
        Console.WriteLine(output);

        Console.WriteLine();

        Console.WriteLine("Checking the result of Intersecting setA, setB\n");

        anotherList = Set.Intersection(setA, setB);

        output = "{";
        foreach (var item in anotherList)
        {
            output += item.ToString() + ", ";
        }

        output = output.Substring(0, output.Length - 2);
        output += "}";
        Console.WriteLine(output);

        Console.WriteLine();


        Console.WriteLine("Checking the result of Differecing setA, setB\n");

        anotherList = Set.Difference(setA, setB);

        output = "{";
        foreach (var item in anotherList)
        {
            output += item.ToString() + ", ";
        }

        output = output.Substring(0, output.Length - 2);
        output += "}";
        Console.WriteLine(output);

        Console.WriteLine();

        Console.WriteLine("Checking the result of complement setA, universal\n");

        anotherList = Set.Complement(setA, new List<object> { 1, 2, 3, 4, 5 });

        output = "{";
        foreach (var item in anotherList)
        {
            output += item.ToString() + ", ";
        }

        output = output.Substring(0, output.Length - 2);
        output += "}";

        Console.WriteLine(output);

        Console.WriteLine("Eval exp\n");

        //List<object> setA = new List<object> { 1, 2, 3, 4 };
        //List<object> setB = new List<object> { };
        //List<object> setC = new List<object> { 4, 5, 6 };
        //Dictionary<string, List<object>> dict = new Dictionary<string, List<object>>();

        //dict["setA"] = setA;
        //dict["setB"] = setB;
        //dict["setC"] = setC;

        //var anotherList = Set.ExpressionEvaluator("setA complement setB union setC", dict);

        //string output = "{";
        //foreach (var item in anotherList)
        //{
        //    output += item.ToString() + ", ";
        //}

        //output = output.Substring(0, output.Length - 2);
        //output += "}";

        //Console.WriteLine(output);
        //var customSubSetList = Set.CustomSubSet(new List<object> { 1, 2, 3 });

        //foreach (var subset in customSubSetList)
        //{
        //    Console.WriteLine("{" + string.Join(", ", subset) + "}");
        //}

    }
}