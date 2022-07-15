using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Shortest_Path
{
    internal class Program
    {
        private static List<int>[] graph;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var e = int.Parse(Console.ReadLine());

            for (int i = 0; i < e; i++)
            {
                var edge = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edge[0];
                var secondNode = edge[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);

                var start = int.Parse(Console.ReadLine());
                var destination = int.Parse(Console.ReadLine());

                BFS(start);
            }
        }

        private static void BFS(int start)
        {
            throw new NotImplementedException();
        }
    }
}