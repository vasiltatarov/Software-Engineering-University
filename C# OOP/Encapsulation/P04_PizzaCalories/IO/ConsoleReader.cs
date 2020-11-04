using System;
using P04_PizzaCalories.IO.Contracts;

namespace P04_PizzaCalories.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
