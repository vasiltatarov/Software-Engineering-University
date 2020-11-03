using System;
using P06_WildFarm.IO.Contracts;

namespace P06_WildFarm.IO
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
