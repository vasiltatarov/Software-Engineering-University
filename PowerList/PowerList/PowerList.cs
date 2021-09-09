using System.Collections;
using System.Collections.Generic;

namespace PowerList
{
    public class PowerList<T> : IPowerList<T>
    {
        private const int DefaultSize = 4;

        private T[] items;

        public PowerList()
            : this(DefaultSize)
        {
        }

        public PowerList(int capacity)
        {
            //ValidateCapacity(capacity);

            this.items = new T[capacity];
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void Resize()
        {
            var newArr = new T[this.items.Length * 2];

            for (int i = 0; i < this.Count; i++)
            {
                newArr[i] = this.items[i];
            }

            this.items = newArr;
        }
    }
}
