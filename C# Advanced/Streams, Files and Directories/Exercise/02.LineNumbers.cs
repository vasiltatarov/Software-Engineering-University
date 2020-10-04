using System.IO;
using System.Linq;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main()
        {
            var lines = File.ReadAllLines(@"..\..\..\text.txt");
            var punctuations = new char[] { '-', ',', '.', '!', '?', '\'' };

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var letters = 0;
                var punctuationMarks = 0;

                for (int k = 0; k < line.Length; k++)
                {
                    var currentChar = line[k];

                    if (char.IsLetter(currentChar))
                    {
                        letters++;
                    }
                    else if (punctuations.Contains(currentChar))
                    {
                        punctuationMarks++;
                    }
                }

                lines[i] = $"Line {i + 1}: {line} ({letters})({punctuationMarks})";
            }

            File.WriteAllLines(@"..\..\..\output.txt", lines);
        }
    }
}
