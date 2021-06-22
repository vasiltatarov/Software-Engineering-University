using System.Collections.Generic;
using Git.ViewModels.Repositories;

namespace Git.Services
{
    public interface IRepositoryService
    {
        IEnumerable<RepositoryViewModel> All();

        void Add(string name, string repositoryType, string userId);

        RepositoryViewModel GetById(string id);
    }
}
