namespace Laboratory_Works__7___Matrix_Calculations
{
    public static class Tasks
    {
        public static void Task1DegreeCalculator()
        {
            Console.WriteLine("Task 1: Degree Calculator\nObjective: Write a program that calculates the degree of each vertex in a graph.\nInput Example:\nGraph: Vertices = {A, B, C}, Edges = {(A, B), (B, C), (C, A)}\n");

            List<char> vertices = ['A', 'B', 'C'];
            List<Tuple<char, char>> edges = [Tuple.Create('A', 'B'), Tuple.Create('B', 'C'), Tuple.Create('C', 'A')];

            Graph.DegreeCalculator(vertices, edges);

            Console.WriteLine("Output: ");
            foreach (var vertex in vertices)
            {
                Console.WriteLine($"Degree of {vertex}: {Graph.GetDegree(vertex)}");
            }
            Console.WriteLine();
        }

        public static void Task2AdjacencyMatrixBuilder() 
        {
            Console.WriteLine("Task 2: Adjacency Matrix Builder\nObjective: Implement a program to create the adjacency matrix of a graph.\nInput Example:\nGraph: Vertices = {1, 2, 3}, Edges = {(1, 2), (2, 3)}\n");

            int numVertices = 3;
            int[,] edges = { { 1, 2 }, { 2, 3 } };

            Graph.AdjacencyMatrixBuilder(numVertices, edges);

            Graph.PrintAdjacencyMatrix();
            Console.WriteLine();
        }

        public static void Task3PathFinder()
        {
            Console.WriteLine("Task 3: Path Finder\nObjective: Create a program to find a path between two vertices in a graph.\nInput Example:\nGraph: Vertices = {1, 2, 3, 4}, Edges = {(1, 2), (2, 3), (3, 4)}\nStart Vertex: 1\nEnd Vertex: 4\n");

            List<int> vertices = [1, 2, 3, 4];
            List<Tuple<int, int>> edges = [Tuple.Create(1, 2), Tuple.Create(2, 3), Tuple.Create(3, 4)];
            int startVertex = 1;
            int endVertex = 4;

            Graph.PathFinder(vertices, edges);

            Console.WriteLine("Output:");
            List<int> path = Graph.FindPath(startVertex, endVertex);

            if (path.Count > 0)
            {
                Console.WriteLine("Path: " + string.Join(" -> ", path));
            }
            else
            {
                Console.WriteLine("No path found.");
            }

            Console.WriteLine();
        }

        public static void Task4SubGraphIdentifier()
        {
            Console.WriteLine("Task 4: Subgraph Identifier\nObjective: Write a program that determines if a given graph is a subgraph of another.\nInput Example:\nMain Graph: Vertices = {A, B, C, D}, Edges = {(A, B), (B, C), (C, D)}\nSubgraph: Vertices = {B, C}, Edges = {(B, C)}\n");

            List<char> mainVertices = ['A', 'B', 'C', 'D'];
            List<Tuple<char, char>> mainEdges = [Tuple.Create('A', 'B'), Tuple.Create('B', 'C'), Tuple.Create('C', 'D')];

            List<char> subVertices = ['B', 'C'];
            List<Tuple<char, char>> subEdges = [Tuple.Create('B', 'C')];

            bool isSubgraph = Graph.IsSubgraph(mainVertices, mainEdges, subVertices, subEdges);

            Console.WriteLine("Output:");
            Console.WriteLine("Is Subgraph: " + isSubgraph);
            Console.WriteLine();
        }

        public static void Task5SumofDegreesChecker()
        {
            Console.WriteLine("Task 5: Sum of Degrees Checker\nObjective: Implement a program to verify the Sum of Degrees of Vertices Theorem in a graph.\nInput Example:\nGraph: Vertices = {1, 2, 3, 4}, Edges = {(1, 2), (2, 3), (3, 4), (4, 1)}\n");

            List<int> vertices = [1, 2, 3, 4];
            List<Tuple<int, int>> edges = [Tuple.Create(1, 2), Tuple.Create(2, 3), Tuple.Create(3, 4), Tuple.Create(4, 1)];

            int sumOfDegrees = Graph.CalculateSumOfDegrees(vertices, edges);
            int twiceNumberOfEdges = edges.Count * 2;

            bool theoremVerified = sumOfDegrees == twiceNumberOfEdges;

            Console.WriteLine("Output:");
            Console.WriteLine("Sum of Degrees: " + sumOfDegrees);
            Console.WriteLine("Theorem Verified: " + theoremVerified);
            Console.WriteLine();
        }

        public static void Task6IncidenceMatrixGenerator()
        {
            Console.WriteLine("Task 6: Incidence Matrix Generator\nObjective: Create a program that generates the incidence matrix of a graph.\nInput Example:\nGraph: Vertices = {A, B, C}, Edges = {(A, B), (B, C)}\n");

            List<char> vertices = ['A', 'B', 'C'];
            List<Tuple<char, char>> edges = [Tuple.Create('A', 'B'), Tuple.Create('B', 'C')];

            int[,] incidenceMatrix = Graph.GenerateIncidenceMatrix(vertices, edges);
            Graph.DisplayIncidenceMatrix(incidenceMatrix);
        }
    }
}