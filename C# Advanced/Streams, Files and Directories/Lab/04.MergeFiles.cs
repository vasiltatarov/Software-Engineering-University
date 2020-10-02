using System.IO;

namespace _4.MergeFiles
{
    class Program
    {
        static void Main()
        {
            var firstNumReader = new StreamReader(@"..\..\..\Input1.txt");
            var secondNumReader = new StreamReader(@"..\..\..\Input2.txt");
            var firstLine = firstNumReader.ReadLine();
            var secondLine = secondNumReader.ReadLine();
            using var writer = new StreamWriter(@"..\..\..\Output.txt");

            while (firstLine != null || secondLine != null)
            {
                if (firstLine != null)
                {
                    writer.WriteLine(firstLine);
                    firstLine = firstNumReader.ReadLine();
                }

                if (secondLine != null)
                {
                    writer.WriteLine(secondLine);
                    secondLine = secondNumReader.ReadLine();
                }
            }
        }
    }
}
