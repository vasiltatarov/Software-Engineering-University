namespace TheRecrutmentTool.Data.Models
{
    public class JobSkill
    {
        public int SkillId { get; set; }

        public Skill Skill { get; set; }

        public int JobId { get; set; }

        public Job Job { get; set; }
    }
}
