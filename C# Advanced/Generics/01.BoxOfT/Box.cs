using System;
using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        public List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public int Count => this.data.Count;

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public T Remove()
        {
            this.EnsureNotEmpty();
            var last = this.data[this.Count - 1];
            this.data.RemoveAt(this.Count - 1);

            return last;
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Box is empty!");
            }
        }
    }
}
