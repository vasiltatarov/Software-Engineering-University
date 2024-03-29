﻿using System.Linq;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<IDriver>
    {
        public override IDriver GetByName(string name)
            => this.Models.FirstOrDefault(x => x.Name == name);
    }
}
