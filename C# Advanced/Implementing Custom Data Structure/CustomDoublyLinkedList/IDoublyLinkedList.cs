using System;
using System.Collections;

namespace CustomDoublyLinkedList
{
    public interface IDoublyLinkedList<T> : IEnumerable
    {
        void AddFirst(T element);

        void AddLast(T element);

        T RemoveFirst();

        T RemoveLast();

        void ForEach(Action<T> action);

        T[] ToArray();
    }
}
