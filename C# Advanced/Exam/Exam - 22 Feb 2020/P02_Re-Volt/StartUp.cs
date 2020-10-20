using System;

namespace P02_Re_Volt
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var countCommand = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var row = 0;
            var col = 0;
            ReadData(matrix, ref row, ref col);

            var command = Console.ReadLine();
            var isTrapOrBonus = false;

            for (int i = 1; i <= countCommand; i++)
            {
                if (!isTrapOrBonus)
                {
                    matrix[row, col] = '-';
                }

                if (command == "up")
                {
                    if (ValidateMove(matrix, row - 1, col))
                    {
                        row -= 1;
                    }
                    else
                    {
                        row = matrix.GetLength(0) - 1;
                    }
                }
                else if (command == "down")
                {
                    if (ValidateMove(matrix, row + 1, col))
                    {
                        row += 1;
                    }
                    else
                    {
                        row = 0;
                    }
                }
                else if (command == "left")
                {
                    if (ValidateMove(matrix, row, col - 1))
                    {
                        col -= 1;
                    }
                    else
                    {
                        col = matrix.GetLength(1) - 1;
                    }
                }
                else if (command == "right")
                {
                    if (ValidateMove(matrix, row, col + 1))
                    {
                        col += 1;
                    }
                    else
                    {
                        col = 0;
                    }
                }

                if (matrix[row, col] == 'B')
                {
                    isTrapOrBonus = true;
                    i--;
                    continue;
                }
                else if (matrix[row, col] == 'T')
                {
                    if (command == "up")
                    {
                        command = "down";
                    }
                    else if (command == "down")
                    {
                        command = "up";
                    }
                    else if (command == "left")
                    {
                        command = "right";
                    }
                    else if (command == "right")
                    {
                        command = "left";
                    }

                    isTrapOrBonus = true;
                    i--;
                    continue;
                }
                else if (matrix[row, col] == 'F')
                {
                    matrix[row, col] = 'f';
                    Console.WriteLine("Player won!");
                    PrintMatrix(matrix);
                    return;
                }
                else
                {
                    isTrapOrBonus = false;
                    matrix[row, col] = 'f';
                }

                if (i != countCommand)
                {
                    command = Console.ReadLine();
                }
            }

            Console.WriteLine("Player lost!");
            PrintMatrix(matrix);
        }

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

        private static bool ValidateMove(char[,] matrix, int row, int col)
            => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);

        private static void ReadData(char[,] matrix, ref int pRow, ref int pCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];

                    if (matrix[row, col] == 'f')
                    {
                        pRow = row;
                        pCol = col;
                    }
                }
            }
        }
    }
}
