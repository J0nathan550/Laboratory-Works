
/// <summary>
/// Custom Set class
/// </summary>
public static class Set
{
    /// <summary>
    /// Creates a set from a list of elements, removing any duplicates
    /// </summary>
    /// <param name="set">a list of everything</param>
    /// <returns>a set from a list of elements, without duplicates</returns>

    private enum PossibleFunctions
    {
        None = 0,
        Intersection = 1,
        Union = 2,
        Difference = 3,
        Complement = 4,
    }

    /// <summary>
    /// Grabs elements that is provided by user and converts to List with this elements.
    /// </summary>
    /// <param name="set">A list of elements that you want to add to list</param>
    /// <returns>A list with custom elements.</returns>
    public static List<object> CreateSet(List<object> set)
    {
        List<object> result = new List<object>();
        if (set.Count == 0)
        {
            Console.WriteLine("Looks like you are tried to add empty list. Operation will return the null list.");
            return result;
        }
        else
        {
            foreach (var item in set)
            {
                if (!result.Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }

    /// <summary>
    /// Adds an element to the set if it's not already present.
    /// </summary>
    /// <param name="set">already existing list of elements</param>
    /// <param name="element">an element that you want to add</param>
    /// <returns>adds to a list the element that is not exist in current list.</returns>
    public static void AddElement(List<object> set, object element)
    {
        if (set.Count == 0 || element == null)
        {
            Console.WriteLine("Looks like the List, or the element that you want to add to list is null, operation will not procide.");
        }
        else
        {
            if (!set.Contains(element))
            {
                set.Add(element);
            }
        }

    }

    /// <summary>
    /// Removes an element if it exists in the set.
    /// </summary>
    /// <param name="set">already existing list of elements</param>
    /// <param name="element">an element that you want to remove</param>
    /// <returns>removes from the list the element that is exist in current list.</returns>
    public static void RemoveElement(List<object> set, object element)
    {
        if (set.Count == 0 || element == null)
        {
            Console.WriteLine("Looks like the List, or the element that you want to remove is null, operation will not procide.");
        }
        else
        {
            if (set.Contains(element))
            {
                set.Remove(element);
            }
        }
    }

    /// <summary>
    /// Returns a boolean indicating if an element is present in the set.
    /// </summary>
    /// <param name="set">List that we want to check</param>
    /// <param name="element">the paramater that you want to check</param>
    /// <returns>The boolean that shows if it is exist or not</returns>
    public static bool ContainsElement(List<object> set, object element)
    {
        if (element != null)
        {
            if (set.Contains(element))
            {
                return true;
            }
            return false;
        }
        else
        {
            Console.WriteLine("The element that was been given is null and cannot be checked!");
        }
        return false;
    }

    /// <summary>
    /// Returns a new set that's the union of the two sets.
    /// </summary>
    /// <param name="setA">first list to unite</param>
    /// <param name="setB">second list to unite</param>
    /// <returns>united list with all elements together (without duplicates)</returns>
    public static List<object> Union(List<object> setA, List<object> setB)
    {
        List<object> result = new List<object>();
        if (setA.Count == 0 || setB.Count == 0)
        {
            result.Add("Lists can't unite, or the input that was represented is null.");
            return result;
        }
        foreach (var item in setA)
        {
            if (!result.Contains(item))
            {
                result.Add(item);
            }
        }
        foreach (var item1 in setB)
        {
            if (!result.Contains(item1))
            {
                result.Add(item1);
            }
        }
        return result;
    }

    /// <summary>
    /// Returns a new set that's the intersection of the two sets.
    /// </summary>
    /// <param name="setA">first list to check the intersection</param>
    /// <param name="setB">second list to check the intersection</param>
    /// <returns>Intersecting element.</returns>
    public static List<object> Intersection(List<object> setA, List<object> setB)
    {
        List<object> result = new List<object>();
        if (setA.Count == 0 || setB.Count == 0)
        {
            result.Add("The input that was given is null. And cannot be operated!");
            return result;
        }
        foreach (var item in setA)
        {
            if (setB.Contains(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    /// <summary>
    /// Returns a set containing elements in setA but not in setB.
    /// </summary>
    /// <param name="setA">first list to check the difference</param>
    /// <param name="setB">second list to check the difference</param>
    /// <returns>different value from the list B</returns>
    public static List<object> Difference(List<object> setA, List<object> setB)
    {
        List<object> result = new List<object>();
        if (setA.Count == 0 || setB.Count == 0)
        {
            result.Add("The input that was given is null. And cannot be operated!");
            return result;
        }
        else
        {
            result.AddRange(setA);
            foreach (var item in setB)
            {
                result.Remove(item);
            }
            return result;
        }
    }

    /// <summary>
    /// Returns the complement of setA in relation to a universal set.
    /// </summary>
    /// <param name="setA">first list to check the complement</param>
    /// <param name="setB">second list to check the complement</param>
    /// <returns>complement value from the universalSet/returns>
    public static List<object> Complement(List<object> setA, List<object> universalSet)
    {
        return Difference(universalSet, setA);
    }

    /// <summary>
    /// Function that takes expression and dictionary variables to operate string tasks.
    /// </summary>
    /// <returns>A result.</returns>
    public static List<object> ExpressionEvaluator(string expression, Dictionary<string, List<object>> setDict)
    {
        string[] expressions = expression.Split(' ');
        List<object> result = new List<object>();
        
        PossibleFunctions currentFunction = PossibleFunctions.None;

        foreach (string exp in expressions)
        {
            if (setDict.ContainsKey(exp))
            {
                if (currentFunction != PossibleFunctions.None)
                {
                    switch (currentFunction)
                    {
                        case PossibleFunctions.Intersection:
                            result = Intersection(result, setDict[exp]);
                            break;
                        case PossibleFunctions.Union:
                            result = Union(result, setDict[exp]);
                            break;
                        case PossibleFunctions.Difference:
                            result = Difference(result, setDict[exp]);
                            break;
                        case PossibleFunctions.Complement:
                            result = Complement(result, setDict[exp]);
                            break;
                    }
                }
                else
                {
                    AddAll(result, setDict[exp]);
                }
            }
            else
            {
                currentFunction = exp switch
                {
                    "union" => PossibleFunctions.Union,
                    "intersection" => PossibleFunctions.Intersection,
                    "difference" => PossibleFunctions.Difference,
                    "complement" => PossibleFunctions.Complement,
                    _ => PossibleFunctions.None
                };

            }
        }
        return result;
    }
   

    public static List<List<object>> CustomSubSet(List<object> list)
    {
        List<List<object>> resultSubset = new List<List<object>>();
        int totalSubsetNumber = 1 << list.Count;

        for (int i = 0; i < totalSubsetNumber; i++)
        {
            List<object> subset = new List<object>();
            for (int j = 0; j < list.Count; j++)
            {
                if ((i & (1 << j)) != 0)
                {
                    subset.Add(list[j]);
                }
            }
            resultSubset.Add(subset);
        }
        return resultSubset;
    }

    private static void AddAll(List<object> list, List<object> fill)
    {
        list.Clear();
        list.AddRange(fill);    
    }
}