using System;
using System.Collections;
using System.Collections.Generic;

namespace _03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> data;

        public Stack()
        {
            this.data = new List<T>();
        }

        public int Count => this.data.Count;

        public void Push(T item)
        {
            this.data.Add(item);
        }

        public T Pop()
        {
            this.EnsureNotEmpty();
            var toRemove = this.data[this.Count - 1];
            this.data.RemoveAt(this.Count - 1);

            return toRemove;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
        }
    }
}
