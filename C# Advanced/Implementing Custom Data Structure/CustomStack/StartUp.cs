using System;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main()
        {
            var stack = new MyStack<int>();

            stack.Push(1);
            stack.Push(4);
            stack.Push(5);
            stack.Push(8);
            stack.Push(11);

            Console.WriteLine(stack.Count);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            Console.WriteLine(stack.Count);

            stack.ForEach(x => Console.Write(x + " "));
        }
    }
}
