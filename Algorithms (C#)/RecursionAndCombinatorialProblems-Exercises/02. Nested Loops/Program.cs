using System;
using System.Collections.Generic;

namespace _02._Nested_Loops
{
    internal class Program
    {
        private static int k;
        private static string[] input;
        private static string[] variations;
        static void Main(string[] args)
        {
            k = int.Parse(Console.ReadLine());

            variations = new string[k];
            input = new string[k];

            for (int i = 0; i < k; i++)
            {
                input[i] = (i + 1).ToString();
            }

            VariationsWithRepetition(0);
        }

        private static void VariationsWithRepetition(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(String.Join(" ", variations));
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                variations[index] = input[i];
                VariationsWithRepetition(index + 1);
            }
        }
    }
}