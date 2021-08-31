namespace TheRecrutmentTool.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Skill;

    public class Skill
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public IEnumerable<CandidateSkill> CandidateSkills { get; set; } = new HashSet<CandidateSkill>();

        public IEnumerable<JobSkill> JobSkills { get; set; } = new HashSet<JobSkill>();
    }
}
