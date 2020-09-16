using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_SimpleCalculator
{
    public class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine().Split().Reverse();
            var stack = new Stack<string>(input);

            while (stack.Count > 1)
            {
                var firstNum = int.Parse(stack.Pop());
                var sign = stack.Pop();
                var secondNum = int.Parse(stack.Pop());

                if (sign == "-")
                {
                    stack.Push((firstNum - secondNum).ToString());
                }
                else if (sign == "+")
                {
                    stack.Push((firstNum + secondNum).ToString());
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
