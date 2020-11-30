namespace Composite.Models
{
    public interface IGiftOperations
    {
        void Add(GiftBase gift);

        void Remove(GiftBase gift); 
    }
}
