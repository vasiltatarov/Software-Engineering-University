using System;
using System.Collections;

namespace CustomDoublyLinkedList
{
    public class LinkedList<T> : ILinkedList<T>
    {
        private Node<T> head;

        public LinkedList()
        {
            this.head = null;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var toInsert = new Node<T>(item);

            if (this.Count == 0)
            {
                this.head = toInsert;
            }
            else
            {
                var current = this.head;
                this.head = toInsert;
                this.head.Next = current;
            }
            
            this.Count++;
        }

        public void AddLast(T item)
        {
            var toInsert = new Node<T>(item);

            if (this.Count == 0)
            {
                this.head = toInsert;
            }
            else
            {
                var current = this.head;
                Node<T> prev = null;

                while (current != null)
                {
                    prev = current;
                    current = current.Next;
                }

                prev.Next = toInsert;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            this.EnsureNotEmpty();
            return this.head.Value;
        }

        public T GetLast()
        {
            this.EnsureNotEmpty();

            var current = this.head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public T RemoveFirst()
        {
            this.EnsureNotEmpty();
            var current = this.head;

            if (this.Count == 1)
            {
                this.head = null;
            }
            else
            {
                this.head = this.head.Next;
            }

            this.Count--;
            return current.Value;
        }

        public T RemoveLast()
        {
            this.EnsureNotEmpty();
            var current = this.head;

            if (this.Count == 1)
            {
                this.head = null;
            }
            else
            {
                Node<T> preLast = null;

                while (current.Next != null)
                {
                    preLast = current;
                    current = current.Next;
                }

                preLast.Next = null;
            }

            this.Count--;
            return current.Value;
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
                throw new InvalidOperationException("Linked List is empty!");
            }
        }
    }
}
