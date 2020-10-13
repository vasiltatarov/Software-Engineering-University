using System;

namespace _03.Stack
{
    public class StartUp
    {
        public static void Main()
        {
            var stack = new Stack<string>();

            while (true)
            {
                var command = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (command[0] == "END")
                    {
                        break;
                    }
                    else if (command[0] == "Push")
                    {
                        for (int i = 1; i < command.Length; i++)
                        {
                            stack.Push(command[i]);
                        }
                    }
                    else if (command[0] == "Pop")
                    {
                        stack.Pop();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            PrintStackTwice(stack);
        }

        private static void PrintStackTwice(Stack<string> stack)
        {
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
