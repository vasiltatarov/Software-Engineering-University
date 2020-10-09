using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main()
        {
            var doublyLinkedList = new DoublyLinkedList<int>();

            doublyLinkedList.AddFirst(5);
            doublyLinkedList.AddFirst(10);
            doublyLinkedList.AddFirst(99);

            doublyLinkedList.AddLast(23);
            doublyLinkedList.AddLast(7);

            Console.WriteLine(doublyLinkedList.RemoveFirst()); //99
            Console.WriteLine(doublyLinkedList.RemoveLast()); //7

            doublyLinkedList.ForEach(n => Console.WriteLine(n)); //10, 5, 23 - Each on the new line!

            var arr = doublyLinkedList.ToArray();

            Console.WriteLine(string.Join(" ", arr)); //10, 5, 23

            //foreach (var n in doublyLinkedList)
            //{
            //    Console.WriteLine(n);
            //}
        }
    }
}
