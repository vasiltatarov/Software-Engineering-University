namespace TheRecrutmentTool.Data.Models
{
    public class CandidateSkill
    {
        public int SkillId { get; set; }

        public Skill Skill { get; set; }

        public int CandidateId { get; set; }

        public Candidate Candidate { get; set; }
    }
}
