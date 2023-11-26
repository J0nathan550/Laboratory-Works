namespace Laboratory_Works__6___KDM_RELATIONS
{
    public static class Tasks
    {
        public static void ReflexivityCheckerFirst()
        {
            Console.WriteLine("First task (Reflexivity Checker):");
            // Set
            var set = new HashSet<int> { 1, 2, 3 };

            // Relation
            var relation = new List<Tuple<int, int>> { Tuple.Create(1, 1), Tuple.Create(2, 2), Tuple.Create(3, 3) };

            // Check if the relation is reflexive
            bool isReflexive = Relations.IsReflexive(set, relation);

            // Output
            Console.WriteLine("Is Reflexive: " + isReflexive);
        }
        public static void SymmetryIdentifierSecond() 
        {
            Console.WriteLine("Second task (Symmetry Identifier):");
            // Relation
            var relation = new List<Tuple<int, int>> { Tuple.Create(1, 2), Tuple.Create(2, 1), Tuple.Create(3, 3) };

            // Check if the relation is symmetric
            bool isSymmetric = Relations.IsSymmetric(relation);

            // Output
            Console.WriteLine("Is Symmetric: " + isSymmetric);
        }
        public static void TransitivityVerifierThird()
        {
            Console.WriteLine("Third task (Transitivity Verifier):");
            // Relation
            var relation = new List<Tuple<int, int>> { Tuple.Create(1, 2), Tuple.Create(2, 3), Tuple.Create(1, 3) };

            // Check if the relation is transitive
            bool isTransitive = Relations.IsTransitive(relation);

            // Output
            Console.WriteLine("Is Transitive: " + isTransitive);
        }
        public static void EquivalenceRelationCheckerFourth()
        {
            Console.WriteLine("Fourth task (Transitivity Verifier):");
            // Set
            var set = new HashSet<int> { 1, 2, 3 };

            // Relation
            var relation = new List<Tuple<int, int>> { Tuple.Create(1, 1), Tuple.Create(2, 2), Tuple.Create(3, 3), Tuple.Create(1, 2), Tuple.Create(2, 1), Tuple.Create(2, 3), Tuple.Create(3, 2) };

            // Check if the relation is an equivalence relation
            bool isEquivalenceRelation = Relations.IsEquivalenceRelation(set, relation);

            // Output
            Console.WriteLine("Is Equivalence Relation: " + isEquivalenceRelation);
        }
        public static void InverseRelationGeneratorFifth()
        {
            Console.WriteLine("Fifth task (Inverse Relation Generator):");
            // Given Relation
            var relation = new List<Tuple<int, int>> { Tuple.Create(1, 2), Tuple.Create(3, 4), Tuple.Create(5, 6) };

            // Generate Inverse Relation
            var inverseRelation = Relations.GenerateInverseRelation(relation);

            // Output
            Console.WriteLine("Inverse Relation: " + string.Join(", ", inverseRelation.Select(pair => $"({pair.Item1}, {pair.Item2})")));
        }
    }
}