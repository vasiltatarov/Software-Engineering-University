using System;
using System.Collections;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public DoublyLinkedList()
        {
            this.head = this.tail = null;
        }

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            var toInsert = new Node<T>(element);

            if (this.Count == 0)
            {
                this.head = this.tail = toInsert;
            }
            else
            {
                toInsert.Next = this.head;
                this.head.Prev = toInsert;
                this.head = toInsert;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            var toInsert = new Node<T>(element);

            if (this.Count == 0)
            {
                this.head = this.tail = toInsert;
            }
            else
            {
                toInsert.Prev = this.tail;
                this.tail.Next = toInsert;
                this.tail = toInsert;
            }

            this.Count++;
        }

        public void ForEach(Action<T> action)
        {
            var current = this.head;

            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        public T RemoveFirst()
        {
            this.EnsureNotEmpty();
            var toRemove = this.head.Value;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.head = this.head.Next;
                this.head.Prev = null;
            }

            this.Count--;
            return toRemove;
        }

        public T RemoveLast()
        {
            this.EnsureNotEmpty();
            var toRemove = this.tail.Value;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.tail = this.tail.Prev;
                this.tail.Next = null;
            }

            this.Count--;
            return toRemove;
        }

        public T[] ToArray()
        {
            var arr = new T[this.Count];
            var counter = 0;
            var current = this.head;

            while (current != null)
            {
                arr[counter] = current.Value;
                counter++;
                current = current.Next;
            }

            return arr;
        }

        public IEnumerator GetEnumerator()
        {
            var current = this.head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Collection is empty!");
            }
        }
    }
}
