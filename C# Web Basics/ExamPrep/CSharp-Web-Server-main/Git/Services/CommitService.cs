using System;
using System.Collections.Generic;
using System.Linq;
using Git.Data;
using Git.Data.Models;
using Git.ViewModels.Commits;

namespace Git.Services
{
    public class CommitService : ICommitService
    {
        private readonly GitDbContext data;

        public CommitService(GitDbContext data) => this.data = data;

        public IEnumerable<CommitViewModel> All(string userId)
            => this.data.Commits
                .Where(x => x.CreatorId == userId)
                .Select(x => new CommitViewModel
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    Description = x.Description,
                    RepositoryName = x.Repository.Name,
                })
                .ToList();

        public void Add(string description, string repoId, string userId)
        {
            var commit = new Commit
            {
                CreatedOn = DateTime.Now,
                CreatorId = userId,
                RepositoryId = repoId,
                Description = description,
            };

            this.data.Commits.Add(commit);
            this.data.SaveChanges();
        }

        public void Delete(string commitId, string userId)
        {
            var commit = this.data.Commits.Find(commitId);
            if (commit == null)
            {
                return;
            }

            if (commit.CreatorId != userId)
            {
                return;
            }

            this.data.Commits.Remove(commit);
            this.data.SaveChanges();
        }
    }
}
