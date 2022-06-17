using System;

namespace _01.ReverseArray
{
    internal class Program
    {
        private static string[] input;
        static void Main(string[] args)
        {
            input = Console.ReadLine().Split();
            var lastIndex = input.Length - 1;

            ReverseArray(0, lastIndex);
        }

        private static void ReverseArray(int startIndex, int lastIndex)
        {
            if (startIndex >= lastIndex)
            {
                Console.WriteLine(string.Join(" ", input));
                return;
            }

            Swap(startIndex, lastIndex);

            ReverseArray(startIndex + 1, lastIndex - 1);
        }

        private static void Swap(int firstSwap, int secondSwap)
        {
            var temp = input[firstSwap];
            input[firstSwap] = input[secondSwap];
            input[secondSwap] = temp;
        }
    }
}