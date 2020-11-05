using System;
using P07MilitaryElite.IO.Contracts;

namespace P04_Telephony.IO
{
    public class ConsoleWriter : Iwriter
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
