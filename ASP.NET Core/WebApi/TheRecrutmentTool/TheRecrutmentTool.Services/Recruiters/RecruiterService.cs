namespace TheRecrutmentTool.Services.Recruiters
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;

    public class RecruiterService : IRecruiterService
    {
        private readonly ApplicationDbContext _data;

        public RecruiterService(ApplicationDbContext data)
            => _data = data;

        public IEnumerable<RecruiterServiceModel> GetAllByLevel(int level)
            => _data
                .Recruiters
                .Where(x => x.ExperienceLevel == level)
                .Select(x => new RecruiterServiceModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Country = x.Country,
                    Email = x.Email,
                    ExperienceLevel = x.ExperienceLevel,
                    InterviewSlots = x.InterviewSlots,
                })
                .ToList();

        public IEnumerable<RecruiterWithCandidatesServiceModel> GetAllWithAvailableCandidates()
            => _data
                .Recruiters
                .Where(x => x.Candidates.Any())
                .Select(x => new RecruiterWithCandidatesServiceModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Country = x.Country,
                    Email = x.Email,
                    ExperienceLevel = x.ExperienceLevel,
                    InterviewSlots = x.InterviewSlots,
                    Candidates = x.Candidates
                        .Select(c => new RecruiterCandidateServiceModel
                        {
                            FirstName = c.FirstName,
                            Email = c.Email,
                            LastName = c.LastName,
                        })
                        .ToList(),
                })
                .ToList();
    }
}
