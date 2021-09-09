using System.Collections.Generic;

namespace PowerList
{
    public interface IPowerList<T> : IEnumerable<T>
    {
        int Count { get; }
        
        T this[int index] { get; set; }

        void Add(T item);

        bool Contains(T item);

        int IndexOf(T item);

        bool Remove(T item);

        void RemoveAt(int index);
    }
}
