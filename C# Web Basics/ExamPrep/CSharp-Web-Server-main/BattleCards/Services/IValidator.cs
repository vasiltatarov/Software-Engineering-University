using System.Collections.Generic;
using BattleCards.ViewModels.Cards;
using BattleCards.ViewModels.Users;

namespace BattleCards.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        ICollection<string> ValidateCard(CardInputModel model);
    }
}
