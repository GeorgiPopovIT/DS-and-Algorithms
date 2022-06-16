using System;
using System.Collections.Generic;

namespace _02._Permutations_with_Repetition
{
    internal class Program
    {
        private static string[] input;

        static void Main(string[] args)
        {
            input = Console.ReadLine().Split();

            Permutate(0);
        }
        private static void Permutate(int index)
        {
            if (index >= input.Length)
            {
                Console.WriteLine(String.Join(" ", input));
                return;
            }

            Permutate(index + 1);

            var used = new HashSet<string>() { input[index] };

            for (int i = index + 1; i < input.Length; i++)
            {
                if (!used.Contains(input[i]))
                {
                    Swap(index, i);
                    Permutate(index + 1);
                    Swap(index, i);

                    used.Add(input[i]);
                }
            }
        }
        private static void Swap(int first, int second)
        {
            var temp = input[first];
            input[first] = input[second];
            input[second] = temp;
        }
    }
}
