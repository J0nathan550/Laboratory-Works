/// <summary>
/// Understand and implement the Cartesian product of sets and related operations.
/// </summary>
public static class Cartesian_Product_and_Relations
{
    /// <summary>
    /// Generates the Cartesian product of two sets.
    /// </summary>
    /// <typeparam name="T1">can be any type paramater, could be good to use int.</typeparam>
    /// <typeparam name="T2">can be any type paramater, could be good to use string.</typeparam>
    /// <param name="setA">First list of ints.</param>
    /// <param name="setB">Second list of strings.</param>
    /// <returns>Whole list of Cartesian Product.</returns>
    public static List<Tuple<T1, T2>> CartesianProduct<T1, T2>(IEnumerable<T1> setA, IEnumerable<T2> setB)
    {
        return setA.SelectMany(a => setB.Select(b => Tuple.Create(a, b))).ToList();
    }

    /// <summary>
    /// Validates if a given relation (list of ordered pairs) is valid for the Cartesian product of two sets.
    /// </summary>
    /// <typeparam name="T1">can be any type paramater, could be good to use int.</typeparam>
    /// <typeparam name="T2">can be any type paramater, could be good to use string.</typeparam>
    /// <param name="relation">List with related objects.</param>
    /// <param name="setA">First list of ints.</param>
    /// <param name="setB">Second list of strings.</param>
    /// <returns>The boolean that validates if lists are valid.</returns>
    public static bool IsRelationValid<T1, T2>(IEnumerable<Tuple<T1, T2>> relation, IEnumerable<T1> setA, IEnumerable<T2> setB)
    {
        return relation.All(pair => setA.Contains(pair.Item1) && setB.Contains(pair.Item2));
    }

    /// <summary>
    /// Finds all the relations for a given set based on a relation function.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setA">can be any type paramater, could be good to use int or string.</param>
    /// <param name="relationFunc">A function related to the list, in this case is dividing.</param>
    /// <returns>Relation in function of division.</returns>
    public static List<Tuple<T, T>> FindRelations<T>(IEnumerable<T> setA, Func<T, T, bool> relationFunc)
    {
        var relations = new List<Tuple<T, T>>();
        foreach (var a in setA)
        {
            foreach (var b in setA)
            {
                if (relationFunc(a, b))
                {
                    relations.Add(Tuple.Create(a, b));
                }
            }
        }
        return relations;
    }

    /// <summary>
    /// Generates the Cartesian product, but only includes pairs that satisfy the filter function.
    /// </summary>
    /// <typeparam name="T1">can be any type, but in this case ONLY int.</typeparam>
    /// <typeparam name="T2">can be any type, but in this case ONLY int.</typeparam>
    /// <param name="setA">First List with ints.</param>
    /// <param name="setB">Second List with ints.</param>
    /// <param name="filterFunc">Only function to filter values.</param>
    /// <returns>Filtered numbers.</returns>
    public static List<Tuple<T1, T2>>? FilteredCartesianProduct<T1, T2>(IEnumerable<T1> setA, IEnumerable<T2> setB, Func<T1, T2, bool> filterFunc)
    {
        try
        {
            return setA.SelectMany(a => setB.Where(b => filterFunc(a, b)).Select(b => Tuple.Create(a, b))).ToList();
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Simple function that checks if number can be divided.
    /// </summary>
    /// <param name="a">number one.</param>
    /// <param name="b">number two.</param>
    /// <returns>boolean to say if it can be divided.</returns>
    public static bool IsDivisible(int a, int b)
    {
        if (a == b)
        {
            return false;
        }
        return a % b == 0;
    }

    /// <summary>
    /// Handy simple function that returns nothing just prints out information in console in a way how represented in a LAB document. 
    /// </summary>
    /// <param name="pairs">a tuple to convert.</param>
    public static void PrintPairs<T1, T2>(IEnumerable<Tuple<T1, T2>> pairs)
    {
        Console.Write("[");
        foreach (var pair in pairs)
        {
            Console.Write($"({pair.Item1}, {pair.Item2})");
        }
        Console.Write("]");
    }
}