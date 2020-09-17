using System;
using System.Collections.Generic;

namespace P08._Balanced_Parentheses
{
    public class StartUp
    {
        static void Main()
        {
            var parantheses = Console.ReadLine();
            var stack = new Stack<char>();

            for (int i = 0; i < parantheses.Length; i++)
            {
                var expectedParantheses = '(';
                var isBalanced = false;

                if (parantheses[i] == ')')
                {
                    isBalanced = true;
                }
                else if (parantheses[i] == ']')
                {
                    expectedParantheses = '[';
                    isBalanced = true;
                }
                else if (parantheses[i] == '}')
                {
                    expectedParantheses = '{';
                    isBalanced = true;
                }
                else
                {
                    stack.Push(parantheses[i]);
                }

                if (isBalanced)
                {
                    if (stack.Count == 0 || stack.Pop() != expectedParantheses)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
