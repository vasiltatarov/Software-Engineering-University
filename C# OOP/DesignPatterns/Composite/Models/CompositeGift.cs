using System;
using System.Collections.Generic;

namespace Composite.Models
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private readonly ICollection<GiftBase> _gifts;

        public CompositeGift(string name, int price) 
            : base(name, price)
        {
            this._gifts = new List<GiftBase>();
        }

        public override int CalculateTotalPrice()
        {
            var total = 0;

            Console.WriteLine($"{this.name} contains the following products with prices:");

            foreach (GiftBase gift in _gifts)
            {
                total += gift.CalculateTotalPrice();
            }

            return total;
        }

        public void Add(GiftBase gift)
        {
            this._gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            this._gifts.Remove(gift);
        }
    }
}
