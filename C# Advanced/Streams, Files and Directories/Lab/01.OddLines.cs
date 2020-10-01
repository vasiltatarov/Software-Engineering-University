using System.IO;

namespace _01.OddLines
{
    public class Program
    {
        static void Main()
        {
            var reader = new StreamReader(@"..\..\..\Input.txt"); // Create text file, if it doesnt exist!
            var line = reader.ReadLine();
            var counter = 0;
            var writer = new StreamWriter(@"..\..\..\Output.txt");

            using (writer)
            {
                while (line != null)
                {
                    if (counter % 2 != 0)
                    {
                        writer.WriteLine(line);
                    }

                    counter++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
