using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Move_Down_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, m];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                var elements = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = elements[c];
                }
            }

            var dp = new int[n, m];
            dp[0,0] = matrix[0,0];

            for (int c = 1; c < m; c++)
            {
                dp[0, c] = dp[0, c - 1] + matrix[0, c]; 
            }

            for (int r = 1; r < n; r++)
            {
                dp[r, 0] = dp[r - 1, 0] + matrix[r, 0];
            }

            for (int r = 1; r < n; r++)
            {
                for (int c = 1; c < m; c++)
                {
                    var upper = dp[r - 1, c];
                    var left = dp[r,c - 1];

                    dp[r, c] = Math.Max(upper, left) + matrix[r, c];
                }
            }

            var path = new Stack<string>();

            var row = n - 1;
            var col = m - 1;

            while (row > 0 && col > 0)
            {
                path.Push($"[{row}, {col}]");

                var upper = dp[row - 1, col];
                var left = dp[row, col - 1];

                if (upper > left)
                {
                    row -= 1;
                }
                else
                {
                    col -= 1;
                }
            }
            while (row > 0)
            {
                path.Push($"[{row}, {col}]");
                row -= 1;
            }
            while (col > 0)
            {
                path.Push($"[{row}, {col}]");
                col -= 1;
            }
            path.Push($"[{row}, {col}]");
            Console.WriteLine(string.Join(" ",path));
        }
    }
}