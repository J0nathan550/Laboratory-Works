namespace Laboratory_Works__6___KDM_RELATIONS
{
    public static class Relations
    {
        public static bool IsReflexive<T>(HashSet<T> set, List<Tuple<T, T>> relation)
        {
            foreach (var element in set)
            {
                if (!relation.Any(pair => pair.Item1.Equals(element) && pair.Item2.Equals(element)))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsSymmetric<T>(List<Tuple<T, T>> relation)
        {
            foreach (var pair in relation)
            {
                if (!relation.Any(p => p.Item1.Equals(pair.Item2) && p.Item2.Equals(pair.Item1)))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsTransitive<T>(List<Tuple<T, T>> relation)
        {
            foreach (var pair1 in relation)
            {
                foreach (var pair2 in relation)
                {
                    if (pair1.Item2.Equals(pair2.Item1) && !relation.Any(p => p.Item1.Equals(pair1.Item1) && p.Item2.Equals(pair2.Item2)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool IsEquivalenceRelation<T>(HashSet<T> set, List<Tuple<T, T>> relation)
        {
            return IsReflexive(set, relation) && IsSymmetric(relation) && IsTransitive(relation);
        }
        public static List<Tuple<T, T>> GenerateInverseRelation<T>(List<Tuple<T, T>> relation)
        {
            return relation.Select(pair => Tuple.Create(pair.Item2, pair.Item1)).ToList();
        }
    }
}