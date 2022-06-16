using System;

namespace _07._N_Choose_K_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine(NChooseKCount(n, k));
        }

        private static int NChooseKCount(int n, int k)
        {
            if (k == 0)
            {
                return 1;

            }
            return (n * NChooseKCount(n - 1, k - 1)) / k;
        }
    }
}
