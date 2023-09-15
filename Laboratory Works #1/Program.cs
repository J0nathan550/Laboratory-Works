﻿class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Creating List\n");
        var result = Set.CreateSet(new List<object> { 1, 3, 3, 2, "hey", "hey" });
        string output = "{";
        foreach (var item in result)
        {
            output += item.ToString() + ", ";
        }

        output = output.Substring(0, output.Length - 2);
        output += "}";
        Console.WriteLine(output);

        Console.WriteLine();

        Console.WriteLine("Adding element 10\n\n");

        Set.AddElement(result, 10);
        output = "{";
        foreach (var item in result)
        {
            output += item.ToString() + ", ";
        }

        output = output.Substring(0, output.Length - 2);
        output += "}";
        Console.WriteLine(output);

        Console.WriteLine();

        Console.WriteLine("Adding element 10, to check if it's duplicating\n\n");

        Set.AddElement(result, 10);
        output = "{";
        foreach (var item in result)
        {
            output += item.ToString() + ", ";
        }

        output = output.Substring(0, output.Length - 2);
        output += "}";
        Console.WriteLine(output);

        Console.WriteLine();

        Console.WriteLine("Removing element 10\n");

        Set.RemoveElement(result, 10);
        output = "{";
        foreach (var item in result)
        {
            output += item.ToString() + ", ";
        }

        output = output.Substring(0, output.Length - 2);
        output += "}";
        Console.WriteLine(output);

        Console.WriteLine();

        Console.WriteLine("Removing element 10 once again to check for error.\n");

        Set.RemoveElement(result, 10);
        output = "{";
        foreach (var item in result)
        {
            output += item.ToString() + ", ";
        }


        output = output.Substring(0, output.Length - 2);
        output += "}";
        Console.WriteLine(output);

        Console.WriteLine();

        Console.WriteLine("Checking if the list contains value 1\n");

        Console.WriteLine(Set.ContainsElement(result, 1));
        Console.WriteLine("Checking if the list contains value 4\n");
        Console.WriteLine(Set.ContainsElement(result, 4));

        Console.WriteLine();

        Console.WriteLine("Checking the result of uniting setA, setB\n");

        List<object> setA = new List<object>() { 1, 2, 3, };
        List<object> setB = new List<object>() { 3, 4, 5 };
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

        List<object> setC = new List<object> { 1, 2, 3 };
        List<object> setD = new List<object> { 4, 6, 7 };
        List<object> setE = new List<object> { 3, 4, 8 };
        Dictionary<string, List<object>> dict = new Dictionary<string, List<object>>();
        
        dict["setC"] = setC;
        dict["setD"] = setD;
        dict["setE"] = setE;

        anotherList = Set.ExpressionEvaluator("setC union setD intersection setE", dict);

        output = "{";
        foreach (var item in anotherList)
        {
            output += item.ToString() + ", ";
        }

        output = output.Substring(0, output.Length - 2);
        output += "}";

        Console.WriteLine(output);

    }
}

/*
 expression                                     result                  optodo
 setC union setD intersection setE              []
            setD intersection setE              [secC]                   union
                 intersection setE              [secC + secD]      
                              setE              [secC + secD]           inters
                                                [secC + secD | setE]  

 
 
 */