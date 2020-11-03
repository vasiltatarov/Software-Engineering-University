using System;

namespace P06_WildFarm.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
            => Console.ReadLine();
    }
}
