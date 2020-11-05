using System;
using P04_Telephony.IO.Contracts;

namespace P04_Telephony.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
