using System;

namespace P02_TronRacers
{
    public static class FirstPlayer
    {
        public static int Row { get; set; }
        public static int Col { get; set; }
    }

    public static class SecondPlayer
    {
        public static int Row { get; set; }
        public static int Col { get; set; }
    }

    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            ReadData(matrix);

            while (true)
            {
                var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                FirstPlayerMove(matrix, command);

                if (matrix[FirstPlayer.Row, FirstPlayer.Col] == 's')
                {
                    matrix[FirstPlayer.Row, FirstPlayer.Col] = 'x';
                    break;
                }

                matrix[FirstPlayer.Row, FirstPlayer.Col] = 'f';

                SecondPlayerMove(matrix, command);

                if (matrix[SecondPlayer.Row, SecondPlayer.Col] == 'f')
                {
                    matrix[SecondPlayer.Row, SecondPlayer.Col] = 'x';
                    break;
                }

                matrix[SecondPlayer.Row, SecondPlayer.Col] = 's';
            }

            PrintMatrix(matrix);
        }

        private static void SecondPlayerMove(char[,] matrix, string[] command)
        {
            var rightCommand = command[1];

            if (rightCommand == "up")
            {
                if (IsValidMove(matrix, SecondPlayer.Row - 1, SecondPlayer.Col))
                {
                    SecondPlayer.Row -= 1;
                }
                else
                {
                    SecondPlayer.Row = matrix.GetLength(0) - 1;
                }
            }
            else if (rightCommand == "down")
            {
                if (IsValidMove(matrix, SecondPlayer.Row + 1, SecondPlayer.Col))
                {
                    SecondPlayer.Row += 1;
                }
                else
                {
                    SecondPlayer.Row = 0;
                }
            }
            else if (rightCommand == "left")
            {
                if (IsValidMove(matrix, SecondPlayer.Row, SecondPlayer.Col - 1))
                {
                    SecondPlayer.Col -= 1;
                }
                else
                {
                    SecondPlayer.Col = matrix.GetLength(1) - 1;
                }
            }
            else if (rightCommand == "right")
            {
                if (IsValidMove(matrix, SecondPlayer.Row, SecondPlayer.Col + 1))
                {
                    SecondPlayer.Col += 1;
                }
                else
                {
                    SecondPlayer.Col = 0;
                }
            }
        }

        private static void FirstPlayerMove(char[,] matrix, string[] command)
        {
            var leftCommand = command[0];

            if (leftCommand == "up")
            {
                if (IsValidMove(matrix, FirstPlayer.Row - 1, FirstPlayer.Col))
                {
                    FirstPlayer.Row -= 1;
                }
                else
                {
                    FirstPlayer.Row = matrix.GetLength(0) - 1;
                }
            }
            else if (leftCommand == "down")
            {
                if (IsValidMove(matrix, FirstPlayer.Row + 1, FirstPlayer.Col))
                {
                    FirstPlayer.Row += 1;
                }
                else
                {
                    FirstPlayer.Row = 0;
                }
            }
            else if (leftCommand == "left")
            {
                if (IsValidMove(matrix, FirstPlayer.Row, FirstPlayer.Col - 1))
                {
                    FirstPlayer.Col -= 1;
                }
                else
                {
                    FirstPlayer.Col = matrix.GetLength(1) - 1;
                }
            }
            else if (leftCommand == "right")
            {
                if (IsValidMove(matrix, FirstPlayer.Row, FirstPlayer.Col + 1))
                {
                    FirstPlayer.Col += 1;
                }
                else
                {
                    FirstPlayer.Col = 0;
                }
            }
        }

        private static bool IsValidMove(char[,] matrix, int row, int col)
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

        private static void ReadData(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];

                    if (matrix[row, col] == 'f')
                    {
                        FirstPlayer.Row = row;
                        FirstPlayer.Col = col;
                    }

                    if (matrix[row, col] == 's')
                    {
                        SecondPlayer.Row = row;
                        SecondPlayer.Col = col;
                    }
                }
            }
        }
    }
}
