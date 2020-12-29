using PlayersAndMonsters.Common;
using PlayersAndMonsters.Core.Factories;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System.Linq;
using System.Text;
using PlayersAndMonsters.Core.Factories.Contracts;

namespace PlayersAndMonsters.Core
{
    using Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;
        private IPlayerRepository playerRepository;
        private ICardRepository cardRepository;
        private IBattleField battleField;

        public ManagerController(IPlayerFactory playerFactory, ICardFactory cardFactory,
            ICardRepository cardRepository, IPlayerRepository playerRepository,
            IBattleField battleField)
        {
            this.playerFactory = playerFactory;
            this.cardFactory = cardFactory;
            this.playerRepository = playerRepository;
            this.cardRepository = cardRepository;
            this.battleField = battleField;
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);

            this.playerRepository.Add(player);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);

            this.cardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            ICard card = this.cardRepository.Cards.FirstOrDefault(x => x.Name == cardName);
            IPlayer player = this.playerRepository.Players.FirstOrDefault(x => x.Username == username);

            player.CardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.playerRepository.Players.FirstOrDefault(x => x.Username == attackUser);
            IPlayer defender = this.playerRepository.Players.FirstOrDefault(x => x.Username == enemyUser);

            this.battleField.Fight(attacker, defender);

            return string.Format(ConstantMessages.FightInfo, attacker.Health, defender.Health);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var player in this.playerRepository.Players)
            {
                sb.AppendLine(player.ToString());

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(card.ToString());
                }

                sb.AppendLine("###");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
