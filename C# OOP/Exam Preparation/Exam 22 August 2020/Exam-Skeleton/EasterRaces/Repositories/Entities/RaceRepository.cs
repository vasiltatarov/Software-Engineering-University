﻿using System.Linq;
using EasterRaces.Models.Races.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
            => this.Models.FirstOrDefault(x => x.Name == name);
    }
}
