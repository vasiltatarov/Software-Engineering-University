using System.Collections;
using System.Collections.Generic;

namespace _02.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> list;

        public Lake(IEnumerable<int> numbers)
        {
            this.list = new List<int>(numbers);
            this.JumpOrder(this.list);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.list.Count; i++)
            {
                yield return this.list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void JumpOrder(ICollection<int> collection)
        {
            var newList = new List<int>();

            for (int i = 0; i < this.list.Count; i++)
            {
                if (i % 2 == 0)
                {
                    newList.Add(this.list[i]);
                }
            }

            for (int i = this.list.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    newList.Add(this.list[i]);
                }
            }

            this.list = newList;
        }

        public override string ToString()
        {
            return string.Join(", ", this.list);
        }
    }
}