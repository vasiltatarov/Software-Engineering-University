using System.Collections;

namespace CustomList
{
    public interface IMyList<T> : IEnumerable
    {
        void Add(T element);
        T RemoveAt(int index);
        bool Contains(T element);
        void Swap(int firstIndex, int secondIndex);
        void Insert(int index, T item);
    }
}
