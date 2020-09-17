using System;
using System.Collections.Generic;
using System.Text;

namespace P09_SimpleTextEditor
{
    public class StartUp
    {
        static void Main()
        {
            var operationsCount = int.Parse(Console.ReadLine());
            var operations = new Stack<string>();
            var text = new StringBuilder();

            for (int i = 0; i < operationsCount; i++)
            {
                var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "1")
                {
                    var str = command[1];
                    operations.Push(text.ToString());
                    text.Append(str);
                }
                else if (command[0] == "2")
                {
                    var countElementsToErases = int.Parse(command[1]);

                    operations.Push(text.ToString());

                    var start = text.Length - countElementsToErases;
                    text = text.Remove(start, countElementsToErases);
                }
                else if (command[0] == "3")
                {
                    var index = int.Parse(command[1]);
                    Console.WriteLine(text[index - 1]);

                    //if (ValidateIndex(index - 1, text.ToString()))
                    //{
                    //    Console.WriteLine(text[index - 1]);
                    //}
                }
                else if (command[0] == "4")
                {
                    text.Clear();
                    text.Append(operations.Pop());
                }
            }
        }

        private static bool ValidateIndex(int index, string text)
            => index >= 0 && index < text.Length;
    }
}
