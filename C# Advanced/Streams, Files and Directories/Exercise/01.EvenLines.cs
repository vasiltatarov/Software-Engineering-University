using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _01.EvenLines
{
    class Program
    {
        static void Main()
        {
            using var reader = new StreamReader(@"..\..\..\text.txt");
            var symbols = new char[] { '-', ',', '.', '!', '?' };
            var counter = 0;
            var line = reader.ReadLine();

            while (line != null)
            {
                var sb = new StringBuilder();

                if (counter % 2 == 0)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        var currentChar = line[i];

                        if (symbols.Contains(currentChar))
                        {
                            sb.Append('@');
                        }
                        else
                        {
                            sb.Append(currentChar);
                        }
                    }

                    var result = sb.ToString().Split();
                    Console.WriteLine(string.Join(" ", result.Reverse()));
                }

                counter++;
                line = reader.ReadLine();
            }
        }
    }
}
