using System;
using System.Linq;

namespace _06._Merge_Sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            var sorted = MergeSort(input);

            Console.WriteLine(string.Join(" ", sorted));
        }

        private static int[] MergeSort(int[] input)
        {
            if (input.Length <= 1)
            {
                return input;
            }

            var left = input.Take(input.Length / 2).ToArray();
            var right = input.Skip(input.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var merged = new int[left.Length + right.Length];

            var mergedIndex = 0;
            var leftIndex = 0;
            var rightIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    merged[mergedIndex++] = left[leftIndex++];
                }
                else
                {
                    merged[mergedIndex++] = right[rightIndex++];
                }
            }

            for (int i = leftIndex; i < left.Length; i++)
            {
                merged[mergedIndex++] = left[i];
            }

            for (int i = rightIndex; i < right.Length; i++)
            {
                merged[mergedIndex++] = right[i];
            }

            return merged;
        }
    }
}
