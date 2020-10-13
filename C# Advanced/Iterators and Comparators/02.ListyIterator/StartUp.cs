using System;
using System.Linq;

namespace _02.ListyIterator
{
    public class StartUp
    {
        public static void Main()
        {
            var collection = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var iterator = new ListyIterator<string>(collection.Skip(1).ToArray());

            while (true)
            {
                var command = Console.ReadLine();

                try
                {
                    if (command == "END")
                    {
                        break;
                    }
                    else if (command == "Move")
                    {
                        Console.WriteLine(iterator.Move());
                    }
                    else if (command == "HasNext")
                    {
                        Console.WriteLine(iterator.HasNext());
                    }
                    else if (command == "Print")
                    {
                        iterator.Print();
                    }
                    else if (command == "PrintAll")
                    {
                        Console.WriteLine(iterator.PrintAll());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
