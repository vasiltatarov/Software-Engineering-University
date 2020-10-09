namespace CustomDoublyLinkedList
{
    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public Node(T value, Node<T> prev, Node<T> next)
            : this(value)
        {
            this.Prev = prev;
            this.Next = next;
        }

        public T Value { get; set; }

        public Node<T> Prev { get; set; }

        public Node<T> Next { get; set; }
    }
}
