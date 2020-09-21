using System;
using System.Linq;

namespace P06_JaggedArrayManipulator
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var jagged = new double[n][];
            ReadValues(jagged);
            AnalyzingJagged(jagged);

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                var args = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (args[0] == "Add")
                {
                    var row = int.Parse(args[1]);
                    var col = int.Parse(args[2]);
                    var value = int.Parse(args[3]);

                    if (ValidateIndex(row, col, jagged))
                    {
                        jagged[row][col] += value;
                    }
                }
                else if (args[0] == "Subtract")
                {
                    var row = int.Parse(args[1]);
                    var col = int.Parse(args[2]);
                    var value = int.Parse(args[3]);

                    if (ValidateIndex(row, col, jagged))
                    {
                        jagged[row][col] -= value;
                    }
                }
            }

            PrintJagged(jagged);
        }

        private static bool ValidateIndex(int row, int col, double[][] jagged)
            => row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row].Length;

        private static void AnalyzingJagged(double[][] jagged)
        {
            for (int i = 0; i < jagged.Length - 1; i++)
            {
                if (jagged[i].Length == jagged[i + 1].Length)
                {
                    jagged[i] = jagged[i].Select(x => x * 2).ToArray();
                    jagged[i + 1] = jagged[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    jagged[i] = jagged[i].Select(x => x / 2).ToArray();
                    jagged[i + 1] = jagged[i + 1].Select(x => x / 2).ToArray();
                }
            }
        }

        private static void PrintJagged(double[][] jagged)
        {
            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void ReadValues(double[][] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                var sequence = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                jagged[row] = sequence;
            }
        }
    }
}
