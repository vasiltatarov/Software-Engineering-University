using System;
using System.Text;

namespace P01_RhombusOfStars
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(MakeRhombus(n));
        }

        private static string MakeRhombus(int n)
        {
            var sb = new StringBuilder();

            for (int i = 1; i <= n; i++)
            {
                sb.AppendLine(PrintRow(n - i, i));
            }

            for (int i = 1; i < n; i++)
            {
                sb.AppendLine(PrintRow(i, n - i));
            }

            return sb.ToString().TrimEnd();
        }

        private static string PrintRow(int spaces, int symbolCount)
        {
            var sb = new StringBuilder();

            sb.Append(' ', spaces);

            for (int i = 0; i < symbolCount; i++)
            {
                sb.Append("* ");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
