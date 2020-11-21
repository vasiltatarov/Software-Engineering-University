using System;
using System.Collections.Generic;
using System.Linq;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly ICollection<IPlayer> _players;

        public PlayerRepository()
        {
            this._players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models
            => (IReadOnlyCollection<IPlayer>)this._players;

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            //if (this._players.Any(x => x.Username == model.Username))//Maybe Not need
            //{
            //    return;
            //}

            this._players.Add(model);
        }

        public bool Remove(IPlayer model)
            => this._players.Remove(model);

        public IPlayer FindByName(string name)
            => this._players.FirstOrDefault(x => x.Username == name);
    }
}
