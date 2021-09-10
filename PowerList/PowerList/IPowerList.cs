using System;
using System.Collections.Generic;

namespace PowerList
{
    public interface IPowerList<T> : IEnumerable<T>
    {
        int Count { get; }
        
        T this[int index] { get; set; }

        void Add(T item);

        void AddAtBottom(T item);

        void AddRange(IEnumerable<T> enumerable);

        void Insert(int index, T item);

        void Clear();

        void Reverse();

        bool Contains(T item);

        bool Remove(T item);

        T RemoveFirst();

        T RemoveLast();

        void RemoveAt(int index);

        int IndexOf(T item);

        void Sort();

        void Sort(Comparison<T> comparison);
    }
}
