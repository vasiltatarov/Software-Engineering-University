using System;

namespace P01Logger.IOProvider
{
    public static class ConsoleWriter
    {
        public static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public static void Write(string text)
        {
            Console.Write(text);
        }
    }
}
