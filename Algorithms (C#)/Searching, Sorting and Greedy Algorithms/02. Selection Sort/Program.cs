using System;
using System.Linq;

namespace _02._Selection_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();


            SelectionSort(input);

            Console.WriteLine(String.Join(" ", input));
        }

        private static void SelectionSort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var min = i;
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[j] < input[min])
                    {
                        min = j;
                    }
                }

                Swap(input, i, min);
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