﻿using System;

namespace RecursiveDrawing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if(n <= 0)
            {
                return;
            }

            PrintFigure(n);
        }

        private static void PrintFigure(int n)
        {
            if(n == 0)
            {
                return ;
            }
            Console.WriteLine(new string('*',n));

            PrintFigure(n - 1);

            Console.WriteLine(new string('#', n));
        }
    }
}
