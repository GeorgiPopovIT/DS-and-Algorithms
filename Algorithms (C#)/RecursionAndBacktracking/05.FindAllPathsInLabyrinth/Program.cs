using System;
using System.Collections.Generic;

namespace _05.FindAllPathsInLabyrinth
{
    internal class Program
    {
        static List<string> directions = new List<string>();

        static void Main(string[] args)
        {
            var lab = ReadLab();

            for (int row = 0; row < lab.GetLength(0); row++)
            {
                var rowData = Console.ReadLine();
                for (int col = 0; col < lab.GetLength(1); col++)
                {
                    lab[row, col] = rowData[col];
                }
            }

            FindPaths(lab, 0, 0, string.Empty);
        }

        private static void FindPaths(char[,] lab, int row, int col, string direction)
        {
            if (IsInBound(lab, row, col))
            {
                return;
            }

            if (lab[row, col] == '*' || lab[row, col] == 'v')
            {
                return;
            }
            directions.Add(direction);

            if (lab[row, col] == 'e')
            {
                Console.WriteLine(String.Join(String.Empty, directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            lab[row, col] = 'v';

            FindPaths(lab, row - 1, col, "U");
            FindPaths(lab, row + 1, col, "D");
            FindPaths(lab, row, col - 1, "L");
            FindPaths(lab, row, col + 1, "R");

            lab[row, col] = '-';

            directions.RemoveAt(directions.Count - 1);

        }
        private static bool IsInBound(char[,] lab, int row, int col)
            => row < 0 || row >= lab.GetLength(0) || col < 0 || col >= lab.GetLength(1);
        private static char[,] ReadLab()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            return new char[rows, cols];
        }
    }
}
