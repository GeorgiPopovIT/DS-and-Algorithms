using System;

namespace _05._Combinations_without_Repetition
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

            CombinationWithoutReps(0,0);
        }

        private static void CombinationWithoutReps(int index,int elementStartIndex)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(String.Join(" ", combinations));
                return;
            }

            for (int i = elementStartIndex; i < input.Length; i++)
            {
                combinations[index] = input[i];
                CombinationWithoutReps(index + 1,i + 1);
            }
        }
    }
}
