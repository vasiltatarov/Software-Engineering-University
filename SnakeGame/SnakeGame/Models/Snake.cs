using CustomDoublyLinkedList;
using SnakeGame.Helper;
using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;

namespace SnakeGame.Models
{
    public class Snake : IDrawable
    {
        public Snake(Position head, Action spawnFood)
        {
            this.SpawnFood = spawnFood;
            this.SnakeBody = new DoublyLinkedList<Position>();
            this.SnakeBody.AddFirst(head);
            this.Foods = new List<Food>();

            for (int i = 0; i < 2; i++)
            {
                this.SnakeBody.AddLast(new Position(head.X + i, head.Y));
            }
        }

        public Action SpawnFood { get; set; }

        public DoublyLinkedList<Position> SnakeBody { get; set; }

        public List<Food> Foods { get; set; }

        public void Draw()
        {
            this.SnakeBody.ForEach(n =>
            {
                var symbol = "*";

                if (n == this.SnakeBody.Head)
                {
                    symbol = "@";
                }

                ConsoleHelper.Write(n.Value, symbol);
            });
        }

        public bool CheckSelfCanibalism()
        {
            var set = new HashSet<Position>();
            var IsContaind = false;

            this.SnakeBody.ForEach(x =>
            {
                if (set.Contains(x.Value))
                {
                    IsContaind = true;
                }

                set.Add(x.Value);
            });

            return IsContaind;
        }

        public void Move(Position position)
        {
            if (position.X == 0 && position.Y == 0)
            {
                return;
            }

            ConsoleHelper.Clear(this.SnakeBody.Tail.Value);

            this.SnakeBody.ReverseForEach(n =>
            {
                if (n.Prev != null)
                {
                    n.Value.X = n.Prev.Value.X;
                    n.Value.Y = n.Prev.Value.Y;
                }
            });

            this.SnakeBody.Head.Value.ChangePosition(position);

            for (int i = 0; i < this.Foods.Count; i++)
            {
                if (this.Foods[i].Position.Equals(this.SnakeBody.Head.Value))
                {
                    this.Foods[i].EatenFood();
                    this.Grow(position);
                    this.SpawnFood();
                    this.SpawnFood();
                    this.SpawnFood();
                }
            }
        }

        public void Grow(Position position) 
        {
            var reverse = new Position(position.X * -1, position.Y * -1);
            var oldPosition = this.SnakeBody.Tail.Value;

            var newHead = new Position(oldPosition.X, oldPosition.Y);
            newHead.ChangePosition(reverse);
            BoundariesChecker.CheckPosition(newHead, reverse);
            this.SnakeBody.AddLast(newHead);
        }
    }
}
