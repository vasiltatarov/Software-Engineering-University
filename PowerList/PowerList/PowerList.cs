using System;
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
            ValidateCapacity(capacity);

            this.items = new T[capacity];
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);

                return this.items[index];
            }
            set
            {
                ValidateIndex(index);

                this.items[index] = value;
            }
        }

        /// <summary>
        /// Adds an item to the end of the PowerList.
        /// </summary>
        public void Add(T item)
        {
            Resize();

            this.items[this.Count] = item;
            this.Count++;
        }

        /// <summary>
        /// Adds an item to the bottom of the PowerList.
        /// </summary>
        public void AddAtBottom(T item)
        {
            Resize();

            for (int i = this.Count; i > 0; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[0] = item;
            this.Count++;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);

            Resize();

            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[index] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Remove(T item)
        {
            var index = this.IndexOf(item);

            if (index >= 0)
            {
                this.RemoveAt(index);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Remove first item of the PowerList.
        /// If there is such no item at the index 0 throws ArgumentOutOfRangeException.
        /// </summary>
        /// <returns>Item at the index 0. If such exist.</returns>
        public T RemoveFirst()
        {
            CheckIfEmpty();

            var itemToRemove = this.items[0];
            this.RemoveAt(0);

            return itemToRemove;
        }

        /// <summary>
        /// Remove last item of the PowerList.
        /// If there is such no item at the last index throws ArgumentOutOfRangeException.
        /// </summary>
        /// <returns>Item at the last index. If such exist.</returns>
        public T RemoveLast()
        {
            CheckIfEmpty();

            var itemToRemove = this.items[this.Count - 1];
            this.items[this.Count - 1] = default;
            this.Count--;

            return itemToRemove;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
            this.Count--;
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
            if (this.Count == this.items.Length)
            {
                var newArr = new T[this.items.Length * 2];

                for (int i = 0; i < this.Count; i++)
                {
                    newArr[i] = this.items[i];
                }

                this.items = newArr;
            }
        }

        private void ValidateCapacity(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void CheckIfEmpty()
        {
            if (this.Count == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
