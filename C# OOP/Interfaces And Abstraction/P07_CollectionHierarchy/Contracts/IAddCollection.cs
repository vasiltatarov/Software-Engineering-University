using System.Collections.Generic;

namespace P07_CollectionHierarchy.Contracts
{
    public interface IAddCollection
    {
        int Add(string item);

        IReadOnlyCollection<string> Collection { get; }
    }
}
