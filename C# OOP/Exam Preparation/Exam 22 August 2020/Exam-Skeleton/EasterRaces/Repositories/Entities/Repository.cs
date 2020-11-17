using System.Collections.Generic;
using System.Linq;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        private ICollection<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }

        public IReadOnlyCollection<T> Models
            => (IReadOnlyCollection<T>) this.models;

        public abstract T GetByName(string name);

        public IReadOnlyCollection<T> GetAll()
            => this.Models;

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public bool Remove(T model)
            => this.models.Remove(model);
    }
}
