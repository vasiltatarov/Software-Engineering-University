using System.Collections.Generic;
using BattleCards.ViewModels.Cards;

namespace BattleCards.Services
{
    public interface ICardService
    {
        IEnumerable<CardViewModel> All();

        IEnumerable<CardViewModel> MyCollection(string userId);

        void Add(string name, string keyword, string imageUrl, int attack, int health, string description);

        void AddToCollection(int cardId, string userId);

        void RemoveFromCollection(int cardId, string userId);
    }
}
