using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly ICollection<ICard> cards;

        public CardRepository()
        {
            cards = new List<ICard>();
        }

        public int Count => Cards.Count;

        public IReadOnlyCollection<ICard> Cards 
            => (IReadOnlyCollection<ICard>)cards;

        public void Add(ICard card)
        {
            CheckIfNull(card);

            if (cards.Any(x => x.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            cards.Add(card);
        }

        public bool Remove(ICard card)
        {
            CheckIfNull(card);
            return cards.Remove(card);
        }

        public ICard Find(string name)
            => cards.FirstOrDefault(x => x.Name == name);

        private static void CheckIfNull(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
        }
    }
}
