using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Distance_Between_Vertices
{
    internal class Program
    {
        private static Dictionary<int, List<int>> graph;

        //private static List<int>[] graph;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var p = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);

            //graph = ReadGraph2(n);


            for (int i = 0; i < p; i++)
            {
                var points = Console.ReadLine()
                    .Split("-")
                    .Select(int.Parse)
                    .ToArray();

                var start = points[0];
                var destiantion = points[1];

                var result = PathCountBFS(start, destiantion);

                Console.WriteLine($"{{{start}, {destiantion}}} -> {result}");
            }


        }

        //private static List<int>[] ReadGraph2(int n)
        //{
        //    graph = new List<int>[n + 1];

        //    for (int node = 0; node < graph.Length; node++)
        //    {
        //        graph[node] = new List<int>();
        //    }

        //    for (int i = 0; i < n; i++)
        //    {
        //        var parts = Console.ReadLine()
        //           .Split(":", StringSplitOptions.RemoveEmptyEntries)
        //           .ToArray();

        //        var firstNode = int.Parse(parts[0]);

        //        if (parts.Length != 1)
        //        {
        //            var children = parts[1]
        //                .Split()
        //                .Select(int.Parse)
        //                .ToList();

        //            graph[firstNode] = children;
        //        }
        //        else
        //        {
        //            graph[firstNode] = new List<int>();
        //        }
        //    }

        //    return graph;
        //}

        //with graph array of lists
        //public static int PathCountBFS(int source, int end)
        //{
        //    var queue = new Queue<int>();

        //    queue.Enqueue(source);

        //    int[] parent = new int[graph.Length];
        //    bool[] visited = new bool[graph.Length];

        //    Array.Fill(parent, -1);

        //    visited[source] = true;

        //    while (queue.Count > 0)
        //    {
        //        var node = queue.Dequeue();

        //        if (node == end)
        //        {
        //            var steps = GetSteps(parent, end);

        //            return steps;
        //        }
        //        foreach (var child in graph[node])
        //        {
        //            if (!visited[child])
        //            {
        //                visited[child] = true;
        //                queue.Enqueue(child);
        //                parent[child] = node;
        //            }
        //        }
        //    }
        //    return -1;
        //}

        public static int PathCountBFS(int start, int end)
        {
            var queue = new Queue<int>();

            var visited = new HashSet<int>() { start };
            var parent = new Dictionary<int, int>() { { start, -1 } };

            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == end)
                {
                    return GetSteps(parent, end);
                }

                foreach (var child in graph[node])
                {

                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    visited.Add(child);
                    queue.Enqueue(child);
                    parent[child] = node;
                }
            }
            return -1;
        }

        private static Dictionary<int, List<int>> ReadGraph(int n)
        {
            var result = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine()
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => e.Trim())
                    .ToArray();

                var key = int.Parse(parts[0]);

                if (parts.Length == 1)
                {
                    result[key] = new List<int>();
                }
                else
                {
                    var children = parts[1].Split().Select(int.Parse).ToList();

                    result[key] = children;
                }
            }

            return result;
        }

        private static int GetSteps(Dictionary<int, int> parent, int destiantion)
        {
            var steps = 0;
            var node = destiantion;

            while (node != -1)
            {
                steps++;
                node = parent[node];
            }

            return steps - 1;
        }

        //private static int GetSteps(int[] parent, int destiantion)
        //{
        //    var steps = 0;
        //    var node = destiantion;

        //    while (node != -1)
        //    {
        //        steps++;
        //        node = parent[node];
        //    }

        //    return steps - 1;
        //}
    }
}
