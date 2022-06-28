using System;
using System.Linq;

namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var key = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(input, key));
        }

        private static int BinarySearch(int[] array, int key)
        {
            var left = 0;
            var right = array.Length - 1;
            

            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (array[mid] == key)
                {
                    return mid;
                }

                if (key > array[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }
    }
}