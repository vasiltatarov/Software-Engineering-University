namespace TheRecrutmentTool.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Job;

    public class Job
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public decimal Salary { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<JobSkill> Skills { get; set; } = new HashSet<JobSkill>();

        public IEnumerable<Interview> Interviews { get; set; } = new HashSet<Interview>();
    }
}
