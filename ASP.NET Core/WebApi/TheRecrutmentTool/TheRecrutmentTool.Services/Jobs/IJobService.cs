namespace TheRecrutmentTool.Services.Jobs
{
    using System.Collections.Generic;
    using Jobs;
    using TheRecrutmentTool.ViewModels.Jobs;

    public interface IJobService
    {
        void Create(JobFormModel model);

        bool Delete(int id);

        IEnumerable<JobServiceModel> GetBySkill(string skill);
    }
}
