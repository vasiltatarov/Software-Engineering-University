namespace TheRecrutmentTool.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Recruiter;

    public class Recruiter
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

        [Required]
        [MaxLength(CountryMaxLength)]
        public string Country { get; set; }

        public int InterviewSlots { get; set; } = 5;

        public int ExperienceLevel { get; set; } = 1;

        public IEnumerable<Candidate> Candidates { get; set; } = new HashSet<Candidate>();
    }
}
