using System;

namespace _01._Permutations_without_Repetition
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
            for (int i = index; i < input.Length; i++)
            {
                Swap(index, i);
                Permutate(index + 1);
                Swap(index, i);
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
