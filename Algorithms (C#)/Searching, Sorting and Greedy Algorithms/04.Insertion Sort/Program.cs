using System;
using System.Linq;

namespace _04.Insertion_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            InsertionSort(input);

            Console.WriteLine(string.Join(" ", input));
        }

        private static void InsertionSort(int[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                int j = i;
                while (j > 0 && input[j - 1] > input[j])
                {
                    Swap(input, j, j - 1);
                    j--;
                }
            }
        }

        private static void Swap(int[] input, int first, int second)
        {
            var temp = input[first];
            input[first] = input[second];
            input[second] = temp;
        }
    }
}