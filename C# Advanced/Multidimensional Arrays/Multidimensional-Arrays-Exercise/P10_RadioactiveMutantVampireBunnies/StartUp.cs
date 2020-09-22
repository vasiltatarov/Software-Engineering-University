using System;
using System.Collections.Generic;
using System.Linq;

namespace P10_RadioactiveMutantVampireBunnies
{
    public class StartUp
    {
        static void Main()
        {
            var sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rowIndex = 0;
            var colIndex = 0;
            var matrix = ReadMatrixData(sizes[0], sizes[1], ref rowIndex, ref colIndex);
            var directions = Console.ReadLine();
            var isWon = false;
            var isDead = false;
            var bunnies = new List<int[]>();

            foreach (var direction in directions)
            {
                if (direction == 'U')
                {
                    matrix[rowIndex, colIndex] = '.';

                    if (IsInside(rowIndex - 1, colIndex, matrix))
                    {
                        rowIndex -= 1;
                    }
                    else
                    {
                        isWon = true;
                    }
                }
                if (direction == 'D')
                {
                    matrix[rowIndex, colIndex] = '.';

                    if (IsInside(rowIndex + 1, colIndex, matrix))
                    {
                        rowIndex += 1;
                    }
                    else
                    {
                        isWon = true;
                    }
                }
                if (direction == 'L')
                {
                    matrix[rowIndex, colIndex] = '.';

                    if (IsInside(rowIndex, colIndex - 1, matrix))
                    {
                        colIndex -= 1;
                    }
                    else
                    {
                        isWon = true;
                    }
                }
                if (direction == 'R')
                {
                    matrix[rowIndex, colIndex] = '.';

                    if (IsInside(rowIndex, colIndex + 1, matrix))
                    {
                        colIndex += 1;
                    }
                    else
                    {
                        isWon = true;
                    }
                }

                if (matrix[rowIndex, colIndex] == 'B')
                {
                    isDead = true;
                }
                else if (matrix[rowIndex, colIndex] == '.' && isWon == false)
                {
                    matrix[rowIndex, colIndex] = 'P';
                }

                FindBunnies(matrix, bunnies);

                foreach (var index in bunnies)
                {
                    var row = index[0];
                    var col = index[1];

                    if (IsInside(row - 1, col, matrix) && matrix[row - 1, col] != 'B')
                    {
                        if (matrix[row - 1, col] == 'P')
                        {
                            isDead = true;
                        }

                        matrix[row - 1, col] = 'B';
                    }
                    if (IsInside(row + 1, col, matrix) && matrix[row + 1, col] != 'B')
                    {
                        if (matrix[row + 1, col] == 'P')
                        {
                            isDead = true;
                        }

                        matrix[row + 1, col] = 'B';
                    }
                    if (IsInside(row, col - 1, matrix) && matrix[row, col - 1] != 'B')
                    {
                        if (matrix[row, col - 1] == 'P')
                        {
                            isDead = true;
                        }

                        matrix[row, col - 1] = 'B';
                    }
                    if (IsInside(row, col + 1, matrix) && matrix[row, col + 1] != 'B')
                    {
                        if (matrix[row, col + 1] == 'P')
                        {
                            isDead = true;
                        }

                        matrix[row, col + 1] = 'B';
                    }
                }

                if (isWon)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {rowIndex} {colIndex}");
                    return;
                }

                if (isDead)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {rowIndex} {colIndex}");
                    return;
                }
            }
        }

        private static void FindBunnies(char[,] matrix, List<int[]> bunnies)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunnies.Add(new int[] { row, col });
                    }
                }
            }
        }

        private static bool IsInside(int row, int col, char[,] matrix)
            => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static char[,] ReadMatrixData(int rows, int cols, ref int rowIndex, ref int colIndex)
        {
            var matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var values = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = values[col];

                    if (matrix[row, col] == 'P')
                    {
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            return matrix;
        }
    }
}
