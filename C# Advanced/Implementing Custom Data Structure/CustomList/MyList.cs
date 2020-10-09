using System;
using System.Collections;

namespace CustomList
{
    public class MyList<T> : IMyList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] data;

        public MyList()
        {
            this.data = new T[DEFAULT_CAPACITY];
        }

        public MyList(int capacity)
        {
            this.data = new T[capacity];
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);

                return this.data[index];
            }
            set
            {
                this.ValidateIndex(index);

                this.data[index] = value;
            }
        }

        public void Add(T element)
        {
            this.Resize();
            this.data[this.Count] = element;
            this.Count++;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.data[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public T RemoveAt(int index)
        {
            this.ValidateIndex(index);
            var toRemove = this.data[index];
            this.data[index] = default;
            this.Shift(index);
            this.Count--;

            if (this.Count <= this.data.Length / 2)
            {
                this.Shrink();
            }

            return toRemove;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.Resize();

            for (int i = this.Count; i > index; i--)
            {
                this.data[i] = this.data[i - 1];
            }

            this.data[index] = item;
            this.Count++;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);

            var temp = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = temp;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.data[i];
            }
        }

        private void Resize()
        {
            if (this.Count == this.data.Length)
            {
                var newArr = new T[this.Count * 2];

                for (int i = 0; i < this.Count; i++)
                {
                    newArr[i] = this.data[i];
                }

                this.data = newArr;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid index!");
            }
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.data[i] = this.data[i + 1];
            }
        }

        private void Shrink()
        {
            var newArr = new T[this.data.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                newArr[i] = this.data[i];
            }

            this.data = newArr;
        }
    }
}
