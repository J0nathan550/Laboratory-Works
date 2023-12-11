namespace Laboratory_Works__7___Matrix_Calculations
{
    public static class Graph
    {
        private static Dictionary<char, List<char>>? adjacencyList = null;
        private static Dictionary<int, List<int>>? adjacencyListPathFinder = null;
        private static int[,]? adjacencyMatrix = null;

        public static void DegreeCalculator(List<char> vertices, List<Tuple<char, char>> edges)
        {
            adjacencyList = [];

            foreach (var vertex in vertices)
            {
                adjacencyList[vertex] = [];
            }

            foreach (var edge in edges)
            {
                adjacencyList[edge.Item1].Add(edge.Item2);
                adjacencyList[edge.Item2].Add(edge.Item1);
            }
        }

        public static void AdjacencyMatrixBuilder(int numVertices, int[,] edges)
        {
            adjacencyMatrix = new int[numVertices, numVertices];

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                int vertex1 = edges[i, 0];
                int vertex2 = edges[i, 1];

                adjacencyMatrix[vertex1 - 1, vertex2 - 1] = 1;
                adjacencyMatrix[vertex2 - 1, vertex1 - 1] = 1;
            }
        }

        public static void PathFinder(List<int> vertices, List<Tuple<int, int>> edges)
        {
            adjacencyListPathFinder = [];

            // Initialize the adjacency list
            foreach (var vertex in vertices)
            {
                adjacencyListPathFinder[vertex] = [];
            }

            foreach (var edge in edges)
            {
                adjacencyListPathFinder[edge.Item1].Add(edge.Item2);
                adjacencyListPathFinder[edge.Item2].Add(edge.Item1);
            }
        }

        public static bool IsSubgraph(List<char> mainVertices, List<Tuple<char, char>> mainEdges, List<char> subVertices, List<Tuple<char, char>> subEdges)
        {
            if (!subVertices.All(mainVertices.Contains))
            {
                return false;
            }

            foreach (var edge in subEdges)
            {
                if (!mainEdges.Contains(edge))
                {
                    return false;
                }
            }

            return true;
        }

        public static int CalculateSumOfDegrees(List<int> vertices, List<Tuple<int, int>> edges)
        {
            Dictionary<int, int> vertexDegrees = [];

            foreach (var vertex in vertices)
            {
                vertexDegrees[vertex] = 0;
            }

            foreach (var edge in edges)
            {
                vertexDegrees[edge.Item1]++;
                vertexDegrees[edge.Item2]++;
            }

            // Calculate the sum of degrees
            int sumOfDegrees = vertexDegrees.Values.Sum();

            return sumOfDegrees;
        }

        public static List<int> FindPath(int startVertex, int endVertex)
        {
            HashSet<int> visited = [];
            List<int> path = [];

            if (DFS(startVertex, endVertex, visited, path))
            {
                return path;
            }

            return [];
        }

        public static int[,] GenerateIncidenceMatrix(List<char> vertices, List<Tuple<char, char>> edges)
        {
            int numVertices = vertices.Count;
            int numEdges = edges.Count;

            int[,] incidenceMatrix = new int[numVertices, numEdges];

            for (int edgeIndex = 0; edgeIndex < numEdges; edgeIndex++)
            {
                Tuple<char, char> edge = edges[edgeIndex];

                int vertex1Index = vertices.IndexOf(edge.Item1);
                int vertex2Index = vertices.IndexOf(edge.Item2);

                // Update the incidence matrix
                incidenceMatrix[vertex1Index, edgeIndex] = 1;
                incidenceMatrix[vertex2Index, edgeIndex] = 1;
            }

            return incidenceMatrix;
        }

        public static void DisplayIncidenceMatrix(int[,] incidenceMatrix)
        {
            Console.WriteLine("Output:");

            Console.WriteLine("Incidence Matrix:");

            for (int i = 0; i < incidenceMatrix.GetLength(0); i++)
            {
                Console.Write("[");
                for (int j = 0; j < incidenceMatrix.GetLength(1); j++)
                {
                    Console.Write(incidenceMatrix[i, j]);

                    if (j < incidenceMatrix.GetLength(1) - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine("]");
            }
        }


        private static bool DFS(int currentVertex, int endVertex, HashSet<int> visited, List<int> path)
        {
            if (adjacencyListPathFinder == null) return false;

            visited.Add(currentVertex);
            path.Add(currentVertex);

            if (currentVertex == endVertex)
            {
                return true;
            }

            foreach (var neighbor in adjacencyListPathFinder[currentVertex])
            {
                if (!visited.Contains(neighbor))
                {
                    if (DFS(neighbor, endVertex, visited, path))
                    {
                        return true;
                    }
                }
            }

            path.Remove(currentVertex);
            return false;
        }

        public static int GetDegree(char vertex)
        {
            if (adjacencyList == null) return 0;
            return adjacencyList[vertex].Count;
        }

        public static void PrintAdjacencyMatrix()
        {
            if (adjacencyMatrix == null)
            {
                Console.WriteLine("Adjacency Matrix is null.");
                return; 
            }

            Console.WriteLine("Output: ");
            Console.WriteLine("Adjacency Matrix");

            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    Console.Write($"{adjacencyMatrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}