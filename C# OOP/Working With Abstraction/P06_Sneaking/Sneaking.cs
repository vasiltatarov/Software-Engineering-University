using System;

namespace P06_Sneaking
{
    public class Sneaking
    {
        private char[][] room;

        public Sneaking(int n)
        {
            this.room = new char[n][];
            this.Sam = new Player();
            this.Enemy = new Player();
        }

        public Player Sam { get; set; }
        public Player Enemy { get; set; }

        public void Procces()
        {
            FillData();

            var moves = Console.ReadLine().ToCharArray();

            for (int i = 0; i < moves.Length; i++)
            {
                for (int row = 0; row < this.room.Length; row++)
                {
                    for (int col = 0; col < this.room[row].Length; col++)
                    {
                        if (this.room[row][col] == 'b')
                        {
                            if (row >= 0 && row < this.room.Length && col + 1 >= 0 && col + 1 < this.room[row].Length)
                            {
                                this.room[row][col] = '.';
                                this.room[row][col + 1] = 'b';
                                col++;
                            }
                            else
                            {
                                this.room[row][col] = 'd';
                            }
                        }
                        else if (this.room[row][col] == 'd')
                        {
                            if (row >= 0 && row < this.room.Length && col - 1 >= 0 && col - 1 < this.room[row].Length)
                            {
                                this.room[row][col] = '.';
                                this.room[row][col - 1] = 'd';
                            }
                            else
                            {
                                this.room[row][col] = 'b';
                            }
                        }
                    }
                }

                for (int j = 0; j < room[this.Sam.Row].Length; j++)
                {
                    if (this.room[this.Sam.Row][j] != '.' && this.room[this.Sam.Row][j] != 'S')
                    {
                        this.Enemy.Row = this.Sam.Row;
                        this.Enemy.Col = j;
                    }
                }

                if (this.Sam.Col < this.Enemy.Col && this.room[this.Enemy.Row][this.Enemy.Col] == 'd' && this.Enemy.Row == this.Sam.Row)
                {
                    this.room[this.Sam.Row][this.Sam.Col] = 'X';
                    Console.WriteLine($"Sam died at {this.Sam.Row}, {this.Sam.Col}");

                    for (int row = 0; row < room.Length; row++)
                    {
                        for (int col = 0; col < room[row].Length; col++)
                        {
                            Console.Write(room[row][col]);
                        }

                        Console.WriteLine();
                    }

                    Environment.Exit(0);
                }
                else if (this.Enemy.Col < this.Sam.Col && this.room[this.Enemy.Row][this.Enemy.Col] == 'b' && this.Enemy.Row == this.Sam.Row)
                {
                    this.room[this.Sam.Row][this.Sam.Col] = 'X';
                    Console.WriteLine($"Sam died at {this.Sam.Row}, {this.Sam.Col}");

                    for (int row = 0; row < room.Length; row++)
                    {
                        for (int col = 0; col < room[row].Length; col++)
                        {
                            Console.Write(room[row][col]);
                        }
                        Console.WriteLine();
                    }

                    Environment.Exit(0);
                }


                this.room[this.Sam.Row][this.Sam.Col] = '.';

                switch (moves[i])
                {
                    case 'U':
                        this.Sam.Row--;
                        break;
                    case 'D':
                        this.Sam.Row++;
                        break;
                    case 'L':
                        this.Sam.Col--;
                        break;
                    case 'R':
                        this.Sam.Col++;
                        break;
                    default:
                        break;
                }

                this.room[this.Sam.Row][this.Sam.Col] = 'S';

                for (int j = 0; j < this.room[this.Sam.Row].Length; j++)
                {
                    if (this.room[this.Sam.Row][j] != '.' && room[this.Sam.Row][j] != 'S')
                    {
                        this.Enemy.Row = this.Sam.Row;
                        this.Enemy.Col = j;
                    }
                }

                if (this.room[this.Enemy.Row][this.Enemy.Col] == 'N' && this.Sam.Row == this.Enemy.Row)
                {
                    this.room[this.Enemy.Row][this.Enemy.Col] = 'X';
                    Console.WriteLine("Nikoladze killed!");

                    for (int row = 0; row < this.room.Length; row++)
                    {
                        for (int col = 0; col < this.room[row].Length; col++)
                        {
                            Console.Write(this.room[row][col]);
                        }

                        Console.WriteLine();
                    }

                    Environment.Exit(0);
                }
            }
        }

        private void FillData()
        {
            for (int row = 0; row < this.room.Length; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                this.room[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    this.room[row][col] = input[col];

                    if (this.room[row][col] == 'S')
                    {
                        this.Sam.Row = row;
                        this.Sam.Col = col;
                    }
                }
            }
        }
    }
}
