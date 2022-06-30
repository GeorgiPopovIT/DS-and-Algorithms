using System;
using System.Linq;

namespace _03._Bubble_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            BubbleSort(input);

            Console.WriteLine(string.Join("",input));
        }

        private static void BubbleSort(int[] input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = 0; j < input.Length - 1; j++)
                {
                    if (input[j] > input[j + 1])
                    {
                        Swap(input, j, j + 1);
                    }
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