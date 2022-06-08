﻿using System;

namespace _03.Generating0or1Vectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var arr = new int[n];

            Gen01(arr, 0);
        }

        private static void Gen01(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(String.Join(String.Empty,arr));
                return;
            }
            for (int i = 0; i < 2; i++)
            {
                arr[index] = i;

                Gen01(arr, index + 1);
            }
        }
    }
}
