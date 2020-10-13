using SnakeGame.LinkedList;
using System;
using System.Collections;

namespace CustomDoublyLinkedList
{
    public interface IDoublyLinkedList<T> : IEnumerable
    {
        void AddFirst(T element);

        void AddLast(T element);

        void ForEach(Action<Node<T>> action);

        void ReverseForEach(Action<Node<T>> action);
    }
}
