using System;

namespace _04.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(SumFactorial(n));
        }

        private static long SumFactorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * SumFactorial(n - 1);

        }
    }
}
