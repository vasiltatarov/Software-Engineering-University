namespace TheRecrutmentTool.Services.Interviews
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;

    public class InterviewService : IInterviewService
    {
        private readonly ApplicationDbContext _data;

        public InterviewService(ApplicationDbContext data)
            => _data = data;

        public IEnumerable<InterviewServiceModel> GetAll()
            => _data
                .Interviews
                .Where(x => !x.Candidate.IsDeleted && !x.Job.IsDeleted)
                .Select(x => new InterviewServiceModel
                {
                    Job = new JobInterviewServiceModel
                    {
                        Title = x.Job.Title,
                        Salary = x.Job.Salary,
                        Description = x.Job.Description,
                    },
                    Candidate = new CandidateInterviewServiceModel
                    {
                        FirstName = x.Candidate.FirstName,
                        LastName = x.Candidate.LastName,
                        Biography = x.Candidate.Biography,
                        Birthdate = x.Candidate.Birthdate,
                        Email = x.Candidate.Email,
                        Recruiter = x.Candidate.Recruiter.FirstName + " " + x.Candidate.Recruiter.LastName
                    }
                })
                .ToList();
    }
}
