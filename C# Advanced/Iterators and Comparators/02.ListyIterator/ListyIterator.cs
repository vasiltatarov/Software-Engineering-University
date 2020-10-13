using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> data;
        private int internalIndex;

        public ListyIterator(params T[] items)
        {
            this.data = new List<T>(items);
            this.internalIndex = 0;
        }

        public bool Move()
        {
            if (this.internalIndex + 1 < this.data.Count)
            {
                this.internalIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.internalIndex + 1 < this.data.Count)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.data[this.internalIndex]);
        }

        public string PrintAll()
        {
            var sb = new StringBuilder();

            foreach (var item in this.data)
            {
                sb.Append(item.ToString() + " ");
            }

            return sb.ToString().TrimEnd();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.data.Count; i++)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
