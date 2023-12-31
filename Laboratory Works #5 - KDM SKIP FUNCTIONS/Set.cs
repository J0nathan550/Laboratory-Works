﻿using System.Collections;

namespace Laboratory
{
    /// <summary>
    /// Represents a collection of unique objects and provides methods to perform basic set operations such as union, intersection, and difference
    /// </summary>
    class Set
    {
        public static Set Empty => new();
        private List<object> _elements = [];
        public int Count => _elements.Count;
        public Set() { }
        public Set(IEnumerable elements)
        {
            AddElements(elements);
        }
        /// <summary>
        /// Adds an element to the set if it is not already present and sort set
        /// </summary>
        /// <param name="element">The new element to add to the set</param>
        public void AddElement(object element)
        {
            if (!Contains(element))
            {
                _elements.Add(element);
            }
        }
        /// <summary>
        /// Adds elements to the set. Existing elements in the set will not be duplicated
        /// </summary>
        /// <param name="elements">The new elements to add to the set</param>
        public void AddElements(IEnumerable elements)
        {
            foreach (object element in elements)
            {
                AddElement(element);
            }
        }
        /// <summary>
        /// Replaces all elements in the set with the specified new elements
        /// </summary>
        /// <param name="elements">The new elements to replace the existing ones in the set</param>
        public void ReplaceElements(IEnumerable elements)
        {
            _elements.Clear();
            AddElements(elements);
        }
        /// <summary>
        /// Removes the specified element from the set if it exists in the set
        /// </summary>
        /// <param name="element">The element to remove</param>
        public void RemoveElement(object element) => _elements.Remove(element);
        /// <summary>
        /// Removes all elements from the set
        /// </summary>
        public void Clear() => _elements.Clear();
        /// <summary>
        /// Checks if the specified element is present in the set
        /// </summary>
        /// <param name="element">The element to check for</param>
        /// <returns>True if the element is found in the set; otherwise, false</returns>
        public bool Contains(object element)
        {
            if (_elements.Count < 1) return false;
            if (element is not null && element.GetType().FullName?.StartsWith("System.ValueTuple") == true)
            {
                foreach (var setElement in _elements)
                {
                    if (element.GetType().FullName?[.."System.ValueTuple`N".Length] != setElement.GetType().FullName?[.."System.ValueTuple`N".Length]) continue;

                    var tupleFields = element.GetType().GetFields();
                    var setTupleFields = setElement.GetType().GetFields();

                    if (tupleFields.Length != setTupleFields.Length) return false;

                    bool tuplesEquals = true;
                    for (int i = 0; i < tupleFields.Length; i++)
                    {
                        var tupleFieldValue = tupleFields[i].GetValue(element);
                        var setTupleFieldValue = setTupleFields[i].GetValue(setElement);

                        if (!Equals(tupleFieldValue, setTupleFieldValue))
                        {
                            tuplesEquals = false;
                        }
                    }
                    if (tuplesEquals) return true;
                }
            }
            else
            {
                foreach (var setElement in _elements)
                {
                    if (setElement.Equals(element)) return true;
                }
            }
            return false; 
        }
        /// <summary>
        /// Compares two sets for equality by checking if they have the same number of elements and all of their elements are the same
        /// </summary>
        /// <param name="first">The first set to compare</param>
        /// <param name="second">The second set to compare</param>
        /// <returns>True if the sets have the same number of elements and all elements are equal; otherwise, false</returns>
        public static bool ElementsAreEqual(Set first, Set second) => first.Count == second.Count && first._elements.SequenceEqual(second._elements);
        /// <summary>
        /// Adds elements from another set to this set. Existing elements in this set will not be duplicated
        /// </summary>
        /// <param name="other">The set whose elements will be added to this set</param>
        public void Union(Set other) => AddElements(other._elements);
        /// <summary>
        /// Combines the elements of the first set with the elements of the second set to create a new set. 
        /// Existing elements in the second set will not be duplicated.
        /// </summary>
        /// <param name="first">The first set to combine</param>
        /// <param name="second">The second set to combine</param>
        /// <returns>A new set containing the combined elements of the two input sets</returns>
        public static Set Union(Set first, Set second)
        {
            var union = new Set(first._elements);
            union.Union(second);
            return union;
        }
        /// <summary>
        /// Modifies this set to contain only the elements that are common with another set
        /// </summary>
        /// <param name="other">The set to intersect with</param>
        public void Intersection(Set other)
        {
            var intersection = new List<object>();
            foreach (object element in other._elements)
            {
                if (Contains(element))
                {
                    intersection.Add(element);
                }
            }
            ReplaceElements(intersection);
        }
        /// <summary>
        /// Computes the intersection of two sets and returns a new set containing the common elements
        /// </summary>
        /// <param name="first">The first set for the intersection</param>
        /// <param name="second">The second set for the intersection</param>
        /// <returns>A new set containing the elements that are common to both input sets</returns>
        public static Set Intersection(Set first, Set second)
        {
            var intersection = new Set();
            foreach (object element in second._elements)
            {
                if (first.Contains(element))
                {
                    intersection.AddElement(element);
                }
            }
            return intersection;
        }
        /// <summary>
        /// Modifies this set to contain only the elements that are not present in another set
        /// </summary>
        /// <param name="other">The set whose elements will be excluded from this set</param>
        public void Difference(Set other)
        {
            var intersection = Intersection(this, other);
            foreach (object element in intersection._elements)
            {
                RemoveElement(element);
            }
        }
        /// <summary>
        /// Computes the set difference between two sets and returns a new set containing the elements that are in the first set but not in the second set
        /// </summary>
        /// <param name="first">The first set for the difference operation</param>
        /// <param name="second">The second set for the difference operation</param>
        /// <returns>A new set containing the elements that are in the first set but not in the second set</returns>
        public static Set Difference(Set first, Set second)
        {
            var difference = new Set(first._elements);
            var intersection = Intersection(first, second);
            foreach (object element in intersection._elements)
            {
                difference.RemoveElement(element);
            }
            return difference;
        }
        /// <summary>
        /// Modifies this set to contain its complement with respect to a given universal set
        /// </summary>
        /// <param name="universalSet">The universal set to compute the complement with</param>
        public void Complement(Set universalSet) => _elements = Difference(universalSet, this)._elements;
        /// <summary>
        /// Computes the complement of a set with respect to a given universal set and returns a new set
        /// </summary>
        /// <param name="set">The set to compute the complement for</param>
        /// <param name="universalSet">The universal set to use as a reference</param>
        /// <returns>A new set containing the complement of the input set with respect to the universal set</returns>
        public static Set Complement(Set set, Set universalSet) => Difference(universalSet, set);
        /// <summary>
        /// Computes the Cartesian product of two sets, resulting in a new set of pairs containing all possible combinations of elements from the input sets
        /// </summary>
        /// <param name="first">The first set</param>
        /// <param name="second">The second set</param>
        /// <returns>A new set representing the Cartesian product of the input sets</returns>
        public static Set CartesianProduct(Set first, Set second)
        {
            var cartesianProduct = new Set();
            foreach (var firstElement in first._elements)
            {
                foreach (var secondElement in second._elements)
                {
                    cartesianProduct.AddElement((firstElement, secondElement));
                }
            }
            return cartesianProduct;
        }
        /// <summary>
        /// Computes the Cartesian product of two sets with generic element types and applies a filter function to include only pairs that satisfy the specified criteria
        /// </summary>
        /// <typeparam name="T1">The expected element type of the first set</typeparam>
        /// <typeparam name="T2">The expected element type of the second set</typeparam>
        /// <param name="first">The first set</param>
        /// <param name="second">The second set</param>
        /// <param name="FilterFunction">A function that defines the filtering criteria for pairs of elements from the two sets</param>
        /// <returns>A new set representing the filtered Cartesian product of the input sets</returns>
        public static Set CartesianProduct<T1, T2>(Set first, Set second, Func<T1,T2,bool> FilterFunction)
        {
            var cartesianProduct = new Set();
            foreach (var firstElement in first._elements)
            {
                if (firstElement is not T1) continue;
                foreach (var secondElement in second._elements)
                {
                    if (secondElement is not T2) continue;
                    if (FilterFunction((T1)firstElement, (T2)secondElement))
                    {
                        cartesianProduct.AddElement((firstElement, secondElement));
                    }
                }
            }
            return cartesianProduct;
        }
        /// <summary>
        /// Computes the Cartesian product of this set with another set and replaces the current contents with the result
        /// </summary>
        /// <param name="other">The other set to compute the Cartesian product with</param>
        public void CartesianProduct(Set other)
        {
            _elements = CartesianProduct(this, other)._elements;
        }
        /// <summary>
        /// Computes the Cartesian product of this set with another set, applying a filter function to include only pairs that satisfy the specified criteria, and replaces the current contents with the result
        /// </summary>
        /// <typeparam name="T1">The expected element type of the first set</typeparam>
        /// <typeparam name="T2">The expected element type of the second set</typeparam>
        /// <param name="other">The other set to compute the Cartesian product with</param>
        /// <param name="FilterFunction">A function that defines the filtering criteria for pairs of elements from the two sets</param>
        public void CartesianProduct<T1, T2>(Set other, Func<T1, T2, bool> FilterFunction)
        {
            _elements = CartesianProduct(this, other, FilterFunction)._elements;
        }
        /// <summary>
        /// Checks if a given relation is valid by comparing it to the Cartesian product of this and other sets
        /// </summary>
        /// <param name="relation">The relation to be checked for validity</param>
        /// <param name="other">The other set involved in the Cartesian product</param>
        /// <returns>True if the relation is the subset of Cartesian product; otherwise, false</returns>
        public bool IsRelationValid(Set relation, Set other) // relation is a set because list of ordered pairs can contains dublicates and it is easier to simply transform it to the Set
        {
            var cartesianProduct = CartesianProduct(this, other);
            foreach (var relationPair in relation._elements)
            {
                if (!cartesianProduct.Contains(relationPair)) return false;
            }
            return true;
        }
        /// <summary>
        /// Checks if a given relation is valid by comparing it to the Cartesian product of two sets
        /// </summary>
        /// <param name="relation">The relation to be checked for validity</param>
        /// <param name="first">The first set involved in the Cartesian product</param>
        /// <param name="second">The second set involved in the Cartesian product</param>
        /// <returns>True if the relation is the subset of Cartesian product; otherwise, false</returns>
        public static bool IsRelationValid(Set relation, Set first, Set second) // relation is a set because list of ordered pairs can contains dublicates and it is easier to simply transform it to the Set
        {
            var cartesianProduct = CartesianProduct(first, second);

            foreach (var relationPair in relation._elements)
            {
                if (!cartesianProduct.Contains(relationPair)) return false;
            }
            return true;
        }
        /// <summary>
        /// Finds relations within a set of elements by applying a relation function
        /// </summary>
        /// <typeparam name="T1">The expected element type of the first set</typeparam>
        /// <typeparam name="T2">The expected element type of the second set</typeparam>
        /// <param name="relationFunction">A function that defines the relation between elements</param>
        /// <returns>A new set containing pairs of elements that satisfy the relation function</returns>
        public Set FindRelations<T1, T2>(Func<T1, T2, bool> relationFunction)
        {
            var relation = new Set();
            foreach (var firstElement in _elements)
            {
                if (firstElement is not T1) continue;
                foreach (var secondElement in _elements)
                {
                    if (secondElement is not T2 || firstElement.Equals(secondElement)) continue;
                    if (relationFunction((T1)firstElement, (T2)secondElement))
                    {
                        relation.AddElement((firstElement, secondElement));
                    }
                }
            }
            return relation;
        }
        /// <summary>
        /// Finds relations within a set of elements by applying a relation function
        /// </summary>
        /// <typeparam name="T1">The expected element type of the first set</typeparam>
        /// <typeparam name="T2">The expected element type of the second set</typeparam>
        /// <param name="set">The set of elements to search for relations in</param>
        /// <param name="relationFunction">A function that defines the relation between elements</param>
        /// <returns>A new set containing pairs of elements that satisfy the relation function</returns>
        public static Set FindRelations<T1, T2>(Set set, Func<T1, T2, bool> relationFunction)
        {
            var relation = new Set();
            foreach (var firstElement in set._elements)
            {
                if (firstElement is not T1) continue;
                foreach (var secondElement in set._elements)
                {
                    if (secondElement is not T2 || firstElement.Equals(secondElement)) continue;
                    if (relationFunction((T1)firstElement, (T2)secondElement))
                    {
                        relation.AddElement((firstElement, secondElement));
                    }
                }
            }
            return relation;
        }

        /// <summary>
        /// Checks if the set consists only of System.ValueTuple`2 types
        /// </summary>
        /// <returns>True if the set consists only of System.ValueTuple`2 types; otherwise, false</returns>
        private bool IsSetOfOrderedPairs()
        {
            foreach (var element in _elements)
            {
                if (element.GetType().FullName?[.."System.ValueTuple`N".Length] != "System.ValueTuple`2")
                {
                    return false;
                }
            }
            return true;
        }
        public Set GetDomain()
        {
            if (IsSetOfOrderedPairs())
            {
                var domain = Empty;
                foreach (var pair in _elements)
                {
                    var pairFields = pair.GetType().GetFields();
                    domain.AddElement(pairFields[0].GetValue(pair));
                }
                return domain;
            }
            else
            { 
                return Empty; 
            }
        }
        public Set GetRange()
        {
            if (IsSetOfOrderedPairs())
            {
                var range = Empty;
                foreach (var pair in _elements)
                {
                    var pairFields = pair.GetType().GetFields();
                    range.AddElement(pairFields[1].GetValue(pair));
                }
                return range;
            }
            else
            {
                return Empty;
            }
        }

        /// <summary>
        /// Checks parity 
        /// </summary>
        public string CheckParity()
        {
            if (IsSetOfOrderedPairs())
            {
                bool isEven = true;
                bool isOdd = true;
                foreach (var pair in _elements)
                {
                    var pairFields = pair.GetType().GetFields();
                    var x = (int?)pairFields[0].GetValue(pair);
                    var y = (int?)pairFields[1].GetValue(pair);

                    if (x == null || y == null)
                    {
                        return "Set doesn't represent a numerical function";
                    }

                    var correspondingPairExists = Contains((-x, y));
                    if (!correspondingPairExists)
                    {
                        Console.WriteLine($"Doesn't contain ({-x}, {y}) to be Even");
                        isEven = false;
                    }

                    var correspondingNegatedPairExists = Contains((-x, -y));
                    if (!correspondingNegatedPairExists)
                    {
                        Console.WriteLine($"Doesn't contain ({-x}, {-y}) to be Odd");
                        isOdd = false;
                    }
                }
                if (isEven)
                {
                    return "Even";
                }
                else if (isOdd)
                {
                    return "Odd";
                }
                else
                {
                    return "Neither even, nor odd";
                }
            }
            else
            {
                return "Set doesn't represent a function";
            }
        }
        /// <summary>
        /// Should return true for domain and range like D: {1, 2, 3} and R: {1, 2, 3, 4, 5}
        /// </summary>
        public bool IsInjective() 
        {
            if (IsSetOfOrderedPairs())
            {
                var map = new Dictionary<object, object>();
                foreach (var pair in _elements)
                {
                    var pairFields = pair.GetType().GetFields();
                    var x = pairFields[0].GetValue(pair);
                    var y = pairFields[1].GetValue(pair);

                    if (map.ContainsKey(x))
                    {
                        return false;
                    }
                    else
                    {
                        if (map.Values.Contains(y))
                        {
                            return false;
                        }
                        map.Add(x, y);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsSurjective()
        {
            if (IsSetOfOrderedPairs())
            {
                var map = new Dictionary<object, object>();
                foreach (var pair in _elements)
                {
                    var pairFields = pair.GetType().GetFields();
                    var x = pairFields[0].GetValue(pair);
                    var y = pairFields[1].GetValue(pair);

                    if (map.ContainsKey(x))
                    {
                        return false;
                    }
                    else
                    {
                        if (map.Values.Contains(y))
                        {
                            return false;
                        }
                        map.Add(x, y);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsSurjective(Set codomain)
        {
            if (IsSetOfOrderedPairs())
            {
                var map = new Dictionary<object, List<object>>();
                foreach (var pair in _elements)
                {
                    var pairFields = pair.GetType().GetFields();
                    var x = pairFields[0].GetValue(pair);
                    var y = pairFields[1].GetValue(pair);

                    if (map.ContainsKey(x))
                    {
                        map[x].Add(y);
                    }
                    else
                    {
                        map.Add(x, [y]);
                    }
                }

                var range =  map.Values.SelectMany(list => list).ToList();
                foreach (var value in codomain._elements)
                {
                    if (!range.Contains(value))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString() => "{ " + string.Join(", ", _elements) + " }";
    }
}