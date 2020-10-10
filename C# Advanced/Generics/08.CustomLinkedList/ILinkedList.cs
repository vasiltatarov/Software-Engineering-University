using System.Collections;

namespace CustomDoublyLinkedList
{
    public interface ILinkedList<T> : IEnumerable
    {
        int Count { get; }

        void AddFirst(T item);

        T RemoveFirst();

        T GetFirst();

        void AddLast(T item);

        T RemoveLast();

        T GetLast();
    }
}
