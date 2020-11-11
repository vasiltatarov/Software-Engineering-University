using System;
using CommandPattern.IOProvider.Contracts;

namespace CommandPattern.IOProvider
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
