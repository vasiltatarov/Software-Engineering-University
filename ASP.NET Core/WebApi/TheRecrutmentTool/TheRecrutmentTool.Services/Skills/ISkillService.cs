namespace TheRecrutmentTool.Services.Skills
{
    using System.Collections.Generic;
    using Models;

    public interface ISkillService
    {
        SkillServiceModel GetById(int id);

        IEnumerable<SkillServiceModel> GetByCandidate(int id);
    }
}
