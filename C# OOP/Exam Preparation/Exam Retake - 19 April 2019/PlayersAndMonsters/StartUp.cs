using PlayersAndMonsters.Core.Factories.Contracts;

namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Repositories;
    using Repositories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            ICardRepository cardRepository = new CardRepository();
            IPlayerRepository playerRepository = new PlayerRepository();

            IPlayerFactory playerFactory = new PlayerFactory();
            ICardFactory cardFactory = new CardFactory();

            IBattleField battleField = new BattleField();

            IManagerController managerController = 
                new ManagerController(playerFactory, cardFactory, cardRepository, playerRepository, battleField);

            IEngine engine = new Engine(reader, writer, managerController);
            engine.Run();
        }
    }
}