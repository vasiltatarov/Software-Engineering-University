using SnakeGame.LinkedList;
using System;
using System.Collections;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public DoublyLinkedList()
        {
            this.Head = this.Tail = null;
        }

        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            var toInsert = new Node<T>(element);

            if (this.Count == 0)
            {
                this.Head = this.Tail = toInsert;
            }
            else
            {
                toInsert.Next = this.Head;
                this.Head.Prev = toInsert;
                this.Head = toInsert;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            var toInsert = new Node<T>(element);

            if (this.Count == 0)
            {
                this.Head = this.Tail = toInsert;
            }
            else
            {
                toInsert.Prev = this.Tail;
                this.Tail.Next = toInsert;
                this.Tail = toInsert;
            }

            this.Count++;
        }

        public void ForEach(Action<Node<T>> action)
        {
            var current = this.Head;

            while (current != null)
            {
                action(current);
                current = current.Next;
            }
        }

        public void ReverseForEach(Action<Node<T>> action)
        {
            var current = this.Tail;

            while (current != null)
            {
                action(current);
                current = current.Prev;
            }
        }

        public IEnumerator GetEnumerator()
        {
            var current = this.Head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    }
}
