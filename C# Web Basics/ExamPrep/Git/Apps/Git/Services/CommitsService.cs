using System;
using System.Collections.Generic;
using System.Linq;
using Git.Data;
using Git.Data.Models;
using Git.ViewModels.Commits;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CommitViewModel> All(string creatorId)
            => this.db.Commits
                .Where(x => x.CreatorId == creatorId)
                .Select(x => new CommitViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    Repository = x.Repository.Name,
                    CreatedOn = x.CreatedOn,
                })
                .ToList();

        public bool IsUserOwner(string commitId, string userId)
            => this.db.Commits
                .Any(x => x.Id == commitId && x.CreatorId == userId);

        public string Add(string description, string creatorId, string repositoryId)
        {
            var commit = new Commit
            {
                Id = Guid.NewGuid().ToString(),
                Description = description,
                CreatedOn = DateTime.Now,
                CreatorId = creatorId,
                RepositoryId = repositoryId,
            };

            this.db.Commits.Add(commit);
            this.db.SaveChanges();

            return commit.Id;
        }

        public CommitRepositoryViewModel GetRepoById(string id)
            => this.db.Repositories
                .Where(x => x.Id == id)
                .Select(x => new CommitRepositoryViewModel
                {
                    Name = x.Name,
                    Id = x.Id,
                })
                .FirstOrDefault();

        public void Delete(string id)
        {
            var commit = this.db.Commits.FirstOrDefault(x => x.Id == id);

            if (commit == null)
            {
                return;
            }

            this.db.Commits.Remove(commit);
            this.db.SaveChanges();
        }
    }
}
