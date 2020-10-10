namespace _07.Tuple
{
    public class Threeuple<T, T1, T2>
    {
        public Threeuple(T item, T1 item1, T2 item2)
        {
            this.Item = item;
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public T Item { get; set; }

        public T1 Item1 { get; set; }

        public T2 Item2 { get; set; }

        public override string ToString()
        {
            return $"{this.Item} -> {this.Item1} -> {this.Item2}";
        }
    }
}
