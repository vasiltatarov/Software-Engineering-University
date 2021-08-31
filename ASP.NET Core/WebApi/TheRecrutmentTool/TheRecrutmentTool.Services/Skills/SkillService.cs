namespace TheRecrutmentTool.Services.Skills
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;

    public class SkillService : ISkillService
    {
        private readonly ApplicationDbContext _data;

        public SkillService(ApplicationDbContext data)
            => _data = data;

        public SkillServiceModel GetById(int id)
            => _data
                .Skills
                .Where(x => x.Id == id)
                .Select(x => new SkillServiceModel
                {
                    Name = x.Name,
                })
                .FirstOrDefault();

        public IEnumerable<SkillServiceModel> GetByCandidate(int id)
            => _data
                .CandidateSkills
                .Where(x => x.CandidateId == id)
                .Select(x => new SkillServiceModel
                {
                    Name = x.Skill.Name,
                })
                .ToList();
    }
}
