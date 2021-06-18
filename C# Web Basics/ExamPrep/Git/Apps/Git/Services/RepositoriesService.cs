using System;
using System.Collections.Generic;
using System.Linq;
using Git.Data;
using Git.Data.Models;
using Git.ViewModels.Repositories;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string Add(string name, string repositoryType, string ownerId)
        {
            var repo = new Repository
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                IsPublic = repositoryType == "Public",
                CreatedOn = DateTime.Now,
                OwnerId = ownerId,
            };

            this.db.Repositories.Add(repo);
            this.db.SaveChanges();

            return repo.Id;
        }

        public IEnumerable<RepositoryViewModel> All()
            => this.db.Repositories
                .Where(x => x.IsPublic)
                .Select(x => new RepositoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Owner = x.Owner.Username,
                    CreatedOn = x.CreatedOn,
                    CommitsCount = x.Commits.Count,
                })
                .ToList();
    }
}
