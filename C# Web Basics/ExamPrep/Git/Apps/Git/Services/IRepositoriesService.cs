using System.Collections.Generic;
using Git.ViewModels.Repositories;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        string Add(string name, string repositoryType, string ownerId);
        
        IEnumerable<RepositoryViewModel> All();
    }
}
