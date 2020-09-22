using System;

namespace P07_KnightGame
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = ReadMatrixData(n);
            var knightsNeedToBeRemove = 0;
            var countAttacks = 0;
            var maxAttack = 0;
            var killerRow = 0;
            var killerCol = 0;

            while (true)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        countAttacks = 0;

                        if (matrix[row, col] == 'K')
                        {
                            if (IsValidMove(row - 2, col - 1, matrix) && matrix[row - 2, col - 1] == 'K')
                            {
                                countAttacks++;
                            }
                            if (IsValidMove(row - 2, col + 1, matrix) && matrix[row - 2, col + 1] == 'K')
                            {
                                countAttacks++;
                            }
                            if (IsValidMove(row - 1, col - 2, matrix) && matrix[row - 1, col - 2] == 'K')
                            {
                                countAttacks++;
                            }
                            if (IsValidMove(row - 1, col + 2, matrix) && matrix[row - 1, col + 2] == 'K')
                            {
                                countAttacks++;
                            }
                            if (IsValidMove(row + 1, col + 2, matrix) && matrix[row + 1, col + 2] == 'K')
                            {
                                countAttacks++;
                            }
                            if (IsValidMove(row + 1, col - 2, matrix) && matrix[row + 1, col - 2] == 'K')
                            {
                                countAttacks++;
                            }
                            if (IsValidMove(row + 2, col - 1, matrix) && matrix[row + 2, col - 1] == 'K')
                            {
                                countAttacks++;
                            }
                            if (IsValidMove(row + 2, col + 1, matrix) && matrix[row + 2, col + 1] == 'K')
                            {
                                countAttacks++;
                            }

                            if (countAttacks > maxAttack)
                            {
                                maxAttack = countAttacks;
                                killerRow = row;
                                killerCol = col;
                            }
                        }
                    }
                }

                if (maxAttack > 0)
                {
                    matrix[killerRow, killerCol] = '0';
                    maxAttack = 0;
                    knightsNeedToBeRemove++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(knightsNeedToBeRemove);
        }

        private static bool IsValidMove(int row, int col, char[,] matrix)
            => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);

        private static char[,] ReadMatrixData(int n)
        {
            var matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var values = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            return matrix;
        }
    }
}
