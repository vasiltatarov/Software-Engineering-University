using System.Collections.Generic;
using P07_CollectionHierarchy.Contracts;

namespace P07_CollectionHierarchy.Models
{
    public class MyList : IMyList
    {
        private List<string> collection;

        public MyList()
        {
            this.collection = new List<string>();
        }

        public int Used => this.collection.Count;

        public IReadOnlyCollection<string> Collection => this.collection;

        public int Add(string item)
        {
            this.collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string toRemove = null;

            if (this.Used != 0)
            {
                toRemove = this.collection[0];
                this.collection.RemoveAt(0);
            }

            return toRemove;
        }
    }
}
