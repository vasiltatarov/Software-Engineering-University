using System;

namespace Database
{
    public class Database
    {
        private int[] data;

        public Database(params int[] data)
        {
            this.data = new int[16];
            this.InitializeArray(data);
        }

        public int Count { get; private set; }

        public void Add(int element)
        {
            if (this.Count == 16)
            {
                throw new InvalidOperationException("Array's capacity must be exactly 16 integers!");
            }

            this.data[this.Count] = element;
            this.Count++;
        }

        public void Remove()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            this.Count--;
            this.data[this.Count] = 0;
        }

        public int[] Fetch()
        {
            int[] coppyArray = new int[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                coppyArray[i] = this.data[i];
            }

            return coppyArray;
        }

        private void InitializeArray(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                this.Add(data[i]);
            }

            this.Count = data.Length;
        }
    }
}
