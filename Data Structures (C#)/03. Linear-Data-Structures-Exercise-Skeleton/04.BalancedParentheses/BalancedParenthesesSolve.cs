namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            var stack = new Stack<char>();

            for (int i = 0; i < parentheses.Length; i++)
            {
                char symbol = parentheses[i];
                if (symbol == '(' || symbol == '{' || symbol == '[')
                {
                    stack.Push(symbol);
                }

                if (symbol == ')' || symbol == '}' || symbol == ']')
                {

                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    if (IsMatching(stack.Peek(),symbol))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsMatching(char open,char closed)
        {
            if (open == '(' && closed == ')')
            {
                return true;
            }
            else if (open == '{' && closed == '}')
            {
                return true;
            }
            else if (open == '[' && closed == ']')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
