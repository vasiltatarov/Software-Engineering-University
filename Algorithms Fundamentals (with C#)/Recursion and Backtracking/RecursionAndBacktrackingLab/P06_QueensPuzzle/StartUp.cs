using System;
using System.Collections.Generic;

namespace P06_QueensPuzzle
{
    public class StartUp
    {
        private const int size = 8;

        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        static void Main()
        {
            var board = new bool[size, size];

            PutQueens(board, 0);
        }

        private static void PutQueens(bool[,] board, int row)
        {
            if (row == board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                //Check whether queen will be attack other queen?
                if (CanPlaceQueen(row, col))
                {
                    //Pre-Actions
                    board[row, col] = true;
                    attackedRows.Add(row);
                    attackedCols.Add(col);
                    attackedLeftDiagonals.Add(row - col);
                    attackedRightDiagonals.Add(row + col);

                    PutQueens(board, row + 1);

                    //Post-Actions
                    board[row, col] = false;
                    attackedRows.Remove(row);
                    attackedCols.Remove(col);
                    attackedLeftDiagonals.Remove(row - col);
                    attackedRightDiagonals.Remove(row + col);
                }
            }
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            if (attackedRows.Contains(row) ||
                attackedCols.Contains(col) ||
                attackedLeftDiagonals.Contains(row - col) ||
                attackedRightDiagonals.Contains(row + col))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == true)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
