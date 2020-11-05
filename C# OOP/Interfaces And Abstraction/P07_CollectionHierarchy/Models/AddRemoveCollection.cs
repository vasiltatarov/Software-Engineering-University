using System.Collections.Generic;
using P07_CollectionHierarchy.Contracts;

namespace P07_CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private List<string> collection;

        public AddRemoveCollection()
        {
            this.collection = new List<string>();
        }

        public IReadOnlyCollection<string> Collection => (IReadOnlyCollection<string>)this.collection;

        public int Add(string item)
        {
            this.collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string toRemove = null;

            if (this.collection.Count != 0)
            {
                toRemove = this.collection[this.collection.Count - 1];
                this.collection.RemoveAt(this.collection.Count - 1);
            }

            return toRemove;
        }
    }
}
