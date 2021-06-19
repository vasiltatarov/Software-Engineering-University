using System.Collections.Generic;
using System.Linq;
using BattleCards.Data;
using BattleCards.Data.Models;
using BattleCards.ViewModels.Cards;

namespace BattleCards.Services
{
    public class CardService : ICardService
    {
        private readonly ApplicationDbContext data;

        public CardService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<CardViewModel> All()
            => this.data.Cards
                .Select(x => new CardViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Attack = x.Attack,
                    Health = x.Health,
                    Keyword = x.Keyword,
                })
                .ToList();

        public IEnumerable<CardViewModel> MyCollection(string userId)
            => this.data.UserCards
                .Where(x => x.UserId == userId)
                .Select(x => new CardViewModel
                {
                    Id = x.Card.Id,
                    Name = x.Card.Name,
                    ImageUrl = x.Card.ImageUrl,
                    Attack = x.Card.Attack,
                    Health = x.Card.Health,
                    Keyword = x.Card.Keyword,
                })
                .ToList();

        public void Add(string name, string keyword, string imageUrl, int attack, int health, string description)
        {
            var card = new Card
            {
                Name = name,
                Keyword = keyword,
                ImageUrl = imageUrl,
                Attack = attack,
                Health = health,
                Description = description,
            };

            this.data.Cards.Add(card);
            this.data.SaveChanges();
        }

        public void AddToCollection(int cardId, string userId)
        {
            if (this.data.UserCards.Any(x => x.CardId == cardId && x.UserId == userId))
            {
                return;
            }

            var userCard = new UserCard
            {
                CardId = cardId,
                UserId = userId,
            };

            this.data.UserCards.Add(userCard);
            this.data.SaveChanges();
        }

        public void RemoveFromCollection(int cardId, string userId)
        {
            var userCard = this.data.UserCards.FirstOrDefault(x => x.UserId == userId && x.CardId == cardId);
            if (userCard == null)
            {
                return;
            }

            this.data.UserCards.Remove(userCard);
            this.data.SaveChanges();
        }
    }
}
