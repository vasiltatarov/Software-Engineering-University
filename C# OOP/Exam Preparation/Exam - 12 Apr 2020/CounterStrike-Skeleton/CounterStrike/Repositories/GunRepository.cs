using System;
using System.Collections.Generic;
using System.Linq;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly ICollection<IGun> _guns;

        public GunRepository()
        {
            this._guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models
            => (IReadOnlyCollection<IGun>)this._guns;

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            //if (this._guns.Any(x => x.Name == model.Name))//Maybe Not need
            //{
            //    return;
            //}

            this._guns.Add(model);
        }

        public bool Remove(IGun model)
            => this._guns.Remove(model);

        public IGun FindByName(string name)
            => this._guns.FirstOrDefault(x => x.Name == name);
    }
}
