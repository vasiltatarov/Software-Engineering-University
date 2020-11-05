using System.Collections.Generic;
using P07_CollectionHierarchy.Contracts;

namespace P07_CollectionHierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        private ICollection<string> collection;

        public AddCollection()
        {
            this.collection = new List<string>();
        }

        public IReadOnlyCollection<string> Collection => (IReadOnlyCollection<string>)this.collection;

        public int Add(string item)
        {
            this.collection.Add(item);
            return this.collection.Count - 1;
        }
    }
}
