namespace TheRecrutmentTool.Services.Interviews
{
    using System.Collections.Generic;
    using Models;

    public interface IInterviewService
    {
        IEnumerable<InterviewServiceModel> GetAll();
    }
}
