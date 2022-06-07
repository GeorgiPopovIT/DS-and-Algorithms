using System;
using System.Linq;

namespace RecursiveArraySum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()?
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(GetSum(numbers));
        }

        public static int GetSum(int[] numbers, int index = 0)
        {
            if (numbers.Length <= index)
            {
                return 0;
            }

            return numbers[index] + GetSum(numbers, index + 1);
        }
    }
}