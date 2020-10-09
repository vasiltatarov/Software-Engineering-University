using System;

namespace CustomStack
{
    public interface IMyStack<T>
    {
        void Push(T element);

        T Pop();

        T Peek();

        void ForEach(Action<T> action);
    }
}
