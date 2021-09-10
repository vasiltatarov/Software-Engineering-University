using System.Collections.Generic;

namespace PowerList
{
    public interface IPowerList<T> : IEnumerable<T>
    {
        int Count { get; }
        
        T this[int index] { get; set; }

        void Add(T item);

        void AddAtBottom(T item);

        void Insert(int index, T item);

        bool Contains(T item);

        bool Remove(T item);

        T RemoveFirst();

        T RemoveLast();

        void RemoveAt(int index);

        int IndexOf(T item);

        PowerList<T> ToPowerList();
    }
}
