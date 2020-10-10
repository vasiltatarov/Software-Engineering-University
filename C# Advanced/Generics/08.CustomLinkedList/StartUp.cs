using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main()
        {
            var linkedList = new LinkedList<int>();

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);
            linkedList.AddFirst(5);
            linkedList.AddFirst(6);

            Console.WriteLine(linkedList.GetFirst());
            Console.WriteLine(linkedList.GetLast());

            Console.WriteLine(linkedList.RemoveFirst());
            Console.WriteLine(linkedList.RemoveLast());
            Console.WriteLine(linkedList.RemoveLast());

            Console.WriteLine(linkedList.Count);
        }
    }
}
