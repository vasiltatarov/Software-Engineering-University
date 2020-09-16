using System;
using System.Collections.Generic;

namespace P04_MatchingBrackets
{
    public class StartUp
    {
        static void Main()
        {
            var expresion = Console.ReadLine();
            var stack = new Stack<int>();

            for (int i = 0; i < expresion.Length; i++)
            {
                if (expresion[i] == '(')
                {
                    stack.Push(i);
                }
                else if (expresion[i] == ')')
                {
                    var startIndex = stack.Pop();
                    var currExpresion = expresion.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(currExpresion);
                }
            }
        }
    }
}
