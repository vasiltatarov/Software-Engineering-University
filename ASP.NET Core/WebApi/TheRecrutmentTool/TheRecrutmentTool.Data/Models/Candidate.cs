namespace TheRecrutmentTool.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Candidate;

    public class Candidate
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime Birthdate { get; set; }

        [Required]
        [MaxLength(BiographyMaxLength)]
        public string Biography { get; set; }

        public int RecruiterId { get; set; }

        public Recruiter Recruiter { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<CandidateSkill> CandidateSkills { get; set; } = new HashSet<CandidateSkill>();

        public IEnumerable<Interview> Interviews { get; set; } = new HashSet<Interview>();
    }
}
