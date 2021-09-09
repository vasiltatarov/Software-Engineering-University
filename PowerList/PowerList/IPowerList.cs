using System.Collections.Generic;

namespace PowerList
{
    public interface IPowerList<T> : IEnumerable<T>
    {
        int Count { get; }

        void Add(T item);
    }
}
