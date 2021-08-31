namespace TheRecrutmentTool.Services.Jobs
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Data.Models;
    using TheRecrutmentTool.ViewModels.Jobs;
    using Jobs;
    using Skills.Models;

    public class JobService : IJobService
    {
        private readonly ApplicationDbContext _data;

        public JobService(ApplicationDbContext data)
            => _data = data;

        public void Create(JobFormModel model)
        {
            var job = new Job
            {
                Title = model.Title,
                Description = model.Description,
                Salary = model.Salary,
            };

            foreach (var jobSkillInputModel in model.Skills)
            {
                var skill = _data.Skills.FirstOrDefault(x => x.Name == jobSkillInputModel.Name);

                _data.JobSkills.Add(new JobSkill
                {
                    Job = job,
                    Skill = skill != null
                        ? skill
                        : new Skill
                        {
                            Name = jobSkillInputModel.Name,
                        },
                });
            }

            _data.Jobs.Add(job);
            _data.SaveChanges();

            var jobId = job.Id;

            StartInterviews(jobId);
        }

        public bool Delete(int id)
        {
            var job = _data.Jobs.FirstOrDefault(x => x.Id == id);

            if (job == null)
            {
                return false;
            }

            job.IsDeleted = true;

            _data.SaveChanges();

            return true;
        }

        public IEnumerable<JobServiceModel> GetBySkill(string skill)
            => _data
                .Jobs
                .Where(x => x.Skills.Any(s => s.Skill.Name.ToLower() == skill.ToLower()) && !x.IsDeleted)
                .Select(x => new JobServiceModel
                {
                    Salary = x.Salary,
                    Description = x.Description,
                    Title = x.Title,
                    Skills = x.Skills
                        .Select(js => new SkillServiceModel
                        {
                            Name = js.Skill.Name,
                        }),
                })
                .ToList();

        private void StartInterviews(int jobId)
        {
            var job = _data.Jobs.FirstOrDefault(x => x.Id == jobId);

            var jobSkills = job.Skills
                .Select(x => x.Skill.Name);

            var candidates = _data
                .Candidates
                .Where(x => !x.IsDeleted)
                .Where(x => x.CandidateSkills.Any(s => jobSkills.Contains(s.Skill.Name)))
                .ToList();

            if (!candidates.Any())
            {
                return;
            }

            foreach (var candidate in candidates)
            {
                var recruiter = _data.Recruiters.FirstOrDefault(x => x.Id == candidate.RecruiterId);

                // If the recruiter does NOT have free slots, an interview should NOT be created.
                if (recruiter.InterviewSlots <= 0)
                {
                    continue;
                }

                recruiter.InterviewSlots--;
                recruiter.ExperienceLevel++;

                var candidateId = candidate.Id;

                var interview = new Interview
                {
                    CandidateId = candidateId,
                    JobId = jobId,
                };

                _data.Interviews.Add(interview);

                _data.SaveChanges();
            }
        }
    }
}
