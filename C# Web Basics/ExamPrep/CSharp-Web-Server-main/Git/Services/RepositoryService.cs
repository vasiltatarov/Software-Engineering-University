using System;
using System.Collections.Generic;
using System.Linq;
using Git.Data;
using Git.Data.Models;
using Git.ViewModels.Repositories;

namespace Git.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly GitDbContext data;

        public RepositoryService(GitDbContext data) => this.data = data;

        public IEnumerable<RepositoryViewModel> All()
            => this.data.Repositories
                .Select(x => new RepositoryViewModel
                {
                    Id = x.Id,
                    Commits = x.Commits.Count,
                    CreatedOn = x.CreatedOn,
                    Name = x.Name,
                    Owner = x.Owner.Username,
                })
                .ToList();

        public void Add(string name, string repositoryType, string userId)
        {
            if (this.data.Repositories.Any(x => x.Name == name))
            {
                return;
            }

            var repo = new Repository
            {
                CreatedOn = DateTime.Now,
                Name = name,
                OwnerId = userId,
                IsPublic = repositoryType == "Public",
            };

            this.data.Repositories.Add(repo);
            this.data.SaveChanges();
        }

        public RepositoryViewModel GetById(string id)
            => this.data.Repositories
                .Where(x => x.Id == id)
                .Select(x => new RepositoryViewModel
                {
                    Id = x.Id,
                    Commits = x.Commits.Count,
                    CreatedOn = x.CreatedOn,
                    Name = x.Name,
                    Owner = x.Owner.Username,
                })
                .FirstOrDefault();
    }
}
