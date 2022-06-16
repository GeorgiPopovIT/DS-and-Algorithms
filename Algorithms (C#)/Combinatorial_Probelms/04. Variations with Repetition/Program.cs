using System;

namespace _04._Variations_with_Repetition
{
    internal class Program
    {
        private static int k;
        private static string[] input;
        private static string[] variations;

        static void Main(string[] args)
        {
            input = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());

            variations = new string[k];

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
