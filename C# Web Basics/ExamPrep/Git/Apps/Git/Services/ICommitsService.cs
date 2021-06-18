using System.Collections.Generic;
using Git.ViewModels.Commits;

namespace Git.Services
{
    public interface ICommitsService
    {
        IEnumerable<CommitViewModel> All(string creatorId);

        bool IsUserOwner(string commitId, string userId);

        string Add(string description, string creatorId, string repositoryId);

        CommitRepositoryViewModel GetRepoById(string id);

        void Delete(string id);
    }
}
