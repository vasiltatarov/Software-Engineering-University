using SnakeGame.Helper;
using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeGame.Models
{
    public class GameEngine
    {
        private bool isStarted = false;
        private List<IDrawable> gameItems;
        private Random rnd = new Random();

        public GameEngine()
        {
            this.gameItems = new List<IDrawable>();
            this.Snake = new Snake(new Position(20, 30), SpawnFood);
            this.gameItems.Add(this.Snake);

            for (int i = 0; i < 10; i++)
            {
                SpawnFood();
            }
        }

        public Snake Snake { get; set; }

        public void Start()
        {
            this.isStarted = true;
            Position movementPosition = new Position(0, 0);

            while (isStarted)
            {
                BoundariesChecker.CheckPosition(this.Snake.SnakeBody.Head.Value, movementPosition);
                this.Snake.Move(movementPosition);

                if (this.Snake.CheckSelfCanibalism())
                {
                    Console.Clear();
                    ConsoleHelper.Write(new Position(0, 0), $"Gmae Over! Your total score is {this.Snake.SnakeBody.Count}");
                    this.isStarted = false;
                    break;
                }

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(false).Key;
                    movementPosition = ReadUserInput.GetMovement(key, movementPosition);   
                }

                Thread.Sleep(50);
                this.gameItems.ForEach(x => x.Draw());
            }
        }

        public void Stop()
        {
            this.isStarted = false;
        }

        private void SpawnFood()
        {
            var food = new Food(new Position(rnd.Next(0, Console.WindowWidth), rnd.Next(0, Console.WindowHeight)));
            this.gameItems.Add(food);
            this.Snake.Foods.Add(food);
        }
    }
}
