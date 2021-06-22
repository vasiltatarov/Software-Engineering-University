using System.Collections.Generic;
using Git.ViewModels.Commits;
using Git.ViewModels.Repositories;
using Git.ViewModels.Users;

namespace Git.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        ICollection<string> ValidateRepository(RepositoryInputModel model);

        ICollection<string> ValidateCommit(CommitInputModel model);
    }
}
