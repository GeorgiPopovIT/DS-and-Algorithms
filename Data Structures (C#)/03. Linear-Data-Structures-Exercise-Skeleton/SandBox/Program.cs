using System;
using Problem04.BalancedParentheses;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            BalancedParenthesesSolve balanced = new BalancedParenthesesSolve();
            Console.WriteLine(balanced.AreBalanced("({})"));
            Console.WriteLine(balanced.AreBalanced("{[()]}"));
            Console.WriteLine(balanced.AreBalanced("{[(]]}"));
        }
    }
}
