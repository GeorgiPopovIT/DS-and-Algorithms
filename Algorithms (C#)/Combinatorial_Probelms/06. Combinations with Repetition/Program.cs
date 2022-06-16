using System;

namespace _06._Combinations_with_Repetition
{
    internal class Program
    {
        private static int k;
        private static string[] input;
        private static string[] combinations;

        static void Main(string[] args)
        {
            input = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());

            combinations = new string[k];

            CombinationWithReps(0, 0);
        }
        private static void CombinationWithReps(int index, int elementStartIndex)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(String.Join(" ", combinations));
                return;
            }

            for (int i = elementStartIndex; i < input.Length; i++)
            {
                combinations[index] = input[i];
                CombinationWithReps(index + 1, i);
            }
        }
    }
}
