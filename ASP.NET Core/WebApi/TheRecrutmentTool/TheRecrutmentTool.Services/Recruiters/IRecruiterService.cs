namespace TheRecrutmentTool.Services.Recruiters
{
    using System.Collections.Generic;
    using Models;

    public interface IRecruiterService
    {
        IEnumerable<RecruiterWithCandidatesServiceModel> GetAllWithAvailableCandidates();

        IEnumerable<RecruiterServiceModel> GetAllByLevel(int level);
    }
}
