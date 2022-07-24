using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Topological_Sorting
{
    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependencies;

        private static Stack<string> sortedDfs;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);

            dependencies = ExtractDependencies(graph);

            var sorted = new List<string>();

            visited = new HashSet<string>();
            sortedDfs = new Stack<string>();
            cycles = new HashSet<string>();

            foreach (var node in graph.Keys)
            {
                try
                {
                    DFS(node);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    return; 
                }
                
            }

            //while (dependencies.Count > 0)
            //{
            //    var nodeToRemove = dependencies.FirstOrDefault(d => d.Value == 0).Key;

            //    if (nodeToRemove == null)
            //    {
            //        break;
            //    }

            //    sorted.Add(nodeToRemove);
            //    dependencies.Remove(nodeToRemove);

            //    foreach (var child in graph[nodeToRemove])
            //    {
            //        dependencies[child]--;
            //    }
            //}

            //if (dependencies.Count == 0)
            //{
               Console.WriteLine($"Topological sorting: {string.Join(", ", sortedDfs)}");
            //}
            //else
            //{
            //    Console.WriteLine("Invalid topological sorting");
            //}
        }

        private static void DFS(string node)
        {
            if (cycles.Contains(node))
            {
                throw new InvalidOperationException("Invalid topological sorting");
            }

            if (visited.Contains(node))
            {
                return;
            }

            cycles.Add(node);
            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            sortedDfs.Push(node);
            cycles.Remove(node);
            //Console.WriteLine(node);
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

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var result = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => e.Trim())
                    .ToArray();

                var key = parts[0]; 

                if (parts.Length == 1)
                {
                    result[key] = new List<string>();
                }
                else
                {
                    var children = parts[1].Split(", ").ToList();

                    result[key] = children;
                }
            }

            return result;
        }
    }
}