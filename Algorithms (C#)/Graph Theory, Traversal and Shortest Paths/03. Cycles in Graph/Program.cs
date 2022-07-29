using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Cycles_in_Graph
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;

        private static Dictionary<string, int> dependencies;

        static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();
            dependencies = ExtractDependencies(graph);

            var sorted = new List<string>();

            while (true)
            {
                var input = Console.ReadLine()
                    .Split('-');

                if (input[0] == "End")
                {
                    break;
                }

                var key = input[0];
                var edge = input[1];

                graph[key] = new List<string>() { edge };
            }

            Console.WriteLine("Acyclic: " + IsGraphAcyclic(sorted));
        }
        private static Dictionary<string, int> ExtractDependencies(Dictionary<string, List<string>> graph)
        {
            var result = new Dictionary<string, int>();
            foreach (var kvp in graph)
            {
                var node = kvp.Key;
                var children = kvp.Value;

                if (!result.ContainsKey(node))
                {
                    result[node] = 0;
                }

                foreach (var child in children)
                {
                    if (!result.ContainsKey(child))
                    {
                        result[child] = 1;
                    }
                    else
                    {
                        result[child]++;
                    }
                }
            }

            return result;
        }
        private static string IsGraphAcyclic(List<string> sorted)
        {
            while (dependencies.Count > 0)
            {
                var nodeToRemove = dependencies.FirstOrDefault(d => d.Value == 0).Key;

                if (nodeToRemove == null)
                {
                    break;
                }

                sorted.Add(nodeToRemove);
                dependencies.Remove(nodeToRemove);

                foreach (var child in graph[nodeToRemove])
                {
                    dependencies[child]--;
                }
            }

            if (dependencies.Count == 0)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }
    }
}