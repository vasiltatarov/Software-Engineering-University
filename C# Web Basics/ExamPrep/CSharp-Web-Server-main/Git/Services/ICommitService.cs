using System.Collections.Generic;
using Git.ViewModels.Commits;

namespace Git.Services
{
    public interface ICommitService
    {
        IEnumerable<CommitViewModel> All(string userId);

        void Add(string description, string repoId, string userId);

        void Delete(string commitId, string userId);
    }
}
