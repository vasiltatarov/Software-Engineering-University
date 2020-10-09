using System;

namespace CustomStack
{
    public class MyStack<T> : IMyStack<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public MyStack()
        {
            this.items = new T[DEFAULT_CAPACITY];
        }

        public MyStack(int capacity)
        {
            this.items = new T[capacity];
        }

        public int Count { get; private set; }

        public T Peek()
        {
            this.EnsureNotEmpty();
            return this.items[this.Count - 1];
        }

        public T Pop()
        {
            this.EnsureNotEmpty();
            var ToRemove = this.Peek();
            this.Count--;

            return ToRemove;
        }

        public void Push(T element)
        {
            this.Resize();
            this.items[this.Count] = element;
            this.Count++;
        }

        public void ForEach(Action<T> action)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                action(this.items[i]);
            }
        }

        private void Resize()
        {
            if (this.Count == this.items.Length)
            {
                var newArr = new T[this.Count * 2];

                for (int i = 0; i < this.Count; i++)
                {
                    newArr[i] = this.items[i];
                }

                this.items = newArr;
            }
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
        }
    }
}
