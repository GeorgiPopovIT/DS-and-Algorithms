using System;

namespace _03._Variations_without_Repetition
{
    internal class Program
    {
        private static int k;
        private static string[] input;
        private static string[] variations;
        private static bool[] used;

        static void Main(string[] args)
        {
            input = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());

            variations = new string[k];
            used = new bool[input.Length];

            VariationsWithoouRepetition(0);
        }

        private static void VariationsWithoouRepetition(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(String.Join(" ",variations));
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variations[index] = input[i];
                    VariationsWithoouRepetition(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}
