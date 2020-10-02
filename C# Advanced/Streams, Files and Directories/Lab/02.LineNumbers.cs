using System.IO;

namespace _2.LineNumbers
{
    class Program
    {
        static void Main()
        {
            var reader = new StreamReader(@"..\..\..\Input.txt");
            var line = reader.ReadLine();
            var counter = 1;
            using var writer = new StreamWriter(@"..\..\..\Output.txt");

            while (line != null)
            {
                writer.WriteLine($"{counter}. {line}");
                counter++;
                line = reader.ReadLine();
            }
        }
    }
}
