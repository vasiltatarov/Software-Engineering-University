using System;

namespace P02_BookWorm
{
    public class StartUp
    {
        static void Main()
        {
            var str = Console.ReadLine();
            var n = int.Parse(Console.ReadLine());

            var matrix = new char[n, n];
            var pRow = 0;
            var pCol = 0;
            ReadMatrix(matrix, ref pRow, ref pCol);

            while (true)
            {
                var command = Console.ReadLine();
                var isValidMove = false;

                if (command == "end")
                {
                    break;
                }
                else if (command == "up")
                {
                    if (IsValidMove(matrix, pRow - 1, pCol))
                    {
                        matrix[pRow, pCol] = '-';
                        pRow -= 1;
                        isValidMove = true;
                    }
                }
                else if (command == "down")
                {
                    if (IsValidMove(matrix, pRow + 1, pCol))
                    {
                        matrix[pRow, pCol] = '-';
                        pRow += 1;
                        isValidMove = true;
                    }
                }
                else if (command == "left")
                {
                    if (IsValidMove(matrix, pRow, pCol - 1))
                    {
                        matrix[pRow, pCol] = '-';
                        pCol -= 1;
                        isValidMove = true;
                    }
                }
                else if (command == "right")
                {
                    if (IsValidMove(matrix, pRow, pCol + 1))
                    {
                        matrix[pRow, pCol] = '-';
                        pCol += 1;
                        isValidMove = true;
                    }
                }

                if (isValidMove)
                {
                    if (matrix[pRow, pCol] != '-')
                    {
                        str += matrix[pRow, pCol];
                    }

                    matrix[pRow, pCol] = 'P';
                }
                else
                {
                    str = str.Substring(0, str.Length - 1);
                }
            }

            Console.WriteLine(str);
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

        private static void ReadMatrix(char[,] matrix, ref int pRow, ref int pCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];

                    if (matrix[row, col] == 'P')
                    {
                        pRow = row;
                        pCol = col;
                    }
                }
            }
        }

        private static bool IsValidMove(char[,] matrix, int row, int col)
            => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
    }
}
