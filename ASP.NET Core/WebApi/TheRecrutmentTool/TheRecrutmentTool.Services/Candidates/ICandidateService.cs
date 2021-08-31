using TheRecrutmentTool.Services.Candidates.Models;

namespace TheRecrutmentTool.Services.Candidates
{
    using System.Collections.Generic;
    using TheRecrutmentTool.ViewModels.Candidates;

    public interface ICandidateService
    {
        void Create(CreateCandidateFormModel model);

        IEnumerable<CandidateServiceModel> GetAll();

        CandidateServiceModel GetById(int id);

        bool EditById(int id, CreateCandidateFormModel model);

        bool DeleteById(int id);
    }
}
