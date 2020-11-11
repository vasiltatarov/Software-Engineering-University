using System;
using CommandPattern.IOProvider.Contracts;

namespace CommandPattern.IOProvider
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void Write(string text)
        {
            Console.Write(text);
        }
    }
}
