namespace Laboratory_Works__6___KDM_RELATIONS
{
    public static class Tasks
    {
        public static void ReflexivityCheckerFirst()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("First task (Reflexivity Checker):");

            var set = new HashSet<int> { 1, 2, 3 };
            var relation = new List<Tuple<int, int>> { Tuple.Create(1, 1), Tuple.Create(2, 2), Tuple.Create(1, 2), Tuple.Create(2, 1) };
            
            string outputSet = "{";
            foreach (var item in set) outputSet += item + ", ";
            outputSet = outputSet.Substring(0, outputSet.Length - 2);
            outputSet += "}";

            string outputRelation = "{";
            foreach (var item in relation) outputRelation += item + ", ";
            outputRelation = outputRelation.Substring(0, outputRelation.Length - 2);
            outputRelation += "}";

            // Check if the relation is reflexive
            bool isReflexive = Relations.IsReflexive(set, relation);

            // Output
            Console.WriteLine($"* Set: {outputSet}\n* Relation: {outputRelation}\nIs Reflexive: {isReflexive}");
            Console.WriteLine();
            Console.ResetColor();
        }
        public static void SymmetryIdentifierSecond() 
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Second task (Symmetry Identifier):");

            var relation = new List<Tuple<int, int>> { Tuple.Create(1, 1), Tuple.Create(2, 2), Tuple.Create(1, 2), Tuple.Create(2, 1) };

            string outputRelation = "{";
            foreach (var item in relation) outputRelation += item + ", ";
            outputRelation = outputRelation.Substring(0, outputRelation.Length - 2);
            outputRelation += "}";

            bool isSymmetric = Relations.IsSymmetric(relation);

            // Output
            Console.WriteLine($"* Relation: {outputRelation}\nIs Symmetric: {isSymmetric}");
            Console.WriteLine();
            Console.ResetColor();
        }
        public static void TransitivityVerifierThird()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Third task (Transitivity Verifier):");
            
            var relation = new List<Tuple<int, int>> { Tuple.Create(1, 1), Tuple.Create(2, 2), Tuple.Create(1, 2), Tuple.Create(2, 1) };

            string outputRelation = "{";
            foreach (var item in relation) outputRelation += item + ", ";
            outputRelation = outputRelation.Substring(0, outputRelation.Length - 2);
            outputRelation += "}";

            bool isTransitive = Relations.IsTransitive(relation);

            // Output
            Console.WriteLine($"* Relation: {outputRelation}\nIs Transitive: {isTransitive}");
            Console.WriteLine();
            Console.ResetColor();
        }
        public static void EquivalenceRelationCheckerFourth()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Fourth task (Equivalence Relation Checker):");

            var set = new HashSet<int> { 1, 2, 3 };
            var relation = new List<Tuple<int, int>> { Tuple.Create(1, 1), Tuple.Create(2, 2), Tuple.Create(1, 2), Tuple.Create(2, 1) };

            string outputSet = "{";
            foreach (var item in set) outputSet += item + ", ";
            outputSet = outputSet.Substring(0, outputSet.Length - 2);
            outputSet += "}";

            string outputRelation = "{";
            foreach (var item in relation) outputRelation += item + ", ";
            outputRelation = outputRelation.Substring(0, outputRelation.Length - 2);
            outputRelation += "}";

            bool isEquivalenceRelation = Relations.IsEquivalenceRelation(set, relation);

            // Output
            Console.WriteLine($"* Set: {outputSet}\n* Relation: {outputRelation}\nEquivalence Relation: {isEquivalenceRelation}");
            Console.WriteLine();
            Console.ResetColor();
        }
        public static void InverseRelationGeneratorFifth()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Fifth task (Inverse Relation Generator):");

            var relation = new List<Tuple<int, int>> { Tuple.Create(1, 1), Tuple.Create(2, 2), Tuple.Create(1, 2), Tuple.Create(2, 1) };

            string outputRelation = "{";
            foreach (var item in relation) outputRelation += item + ", ";
            outputRelation = outputRelation.Substring(0, outputRelation.Length - 2);
            outputRelation += "}";

            var inverseRelation = Relations.GenerateInverseRelation(relation);

            // Output
            Console.WriteLine($"* Relation: {outputRelation}\nInverse Relation: " + string.Join(", ", inverseRelation.Select(pair => "{" + $"({pair.Item1}, {pair.Item2})" + "}")));
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}