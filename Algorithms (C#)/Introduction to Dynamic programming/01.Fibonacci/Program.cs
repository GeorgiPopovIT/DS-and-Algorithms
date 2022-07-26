using System;
using System.Collections.Generic;

namespace _01.Fibonacci
{
    internal class Program
    {
        private static Dictionary<int, long> cache = new Dictionary<int, long>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(FibonacciOpt(n));
        }

        private static long FibonacciOpt(int n)
        {
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }

            var result = FibonacciOpt(n - 1) + FibonacciOpt(n - 2);

            cache[n] = result;

            return result;
        }
    }
}