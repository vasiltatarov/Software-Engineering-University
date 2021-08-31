namespace TheRecrutmentTool.Services.Recruiters.Models
{
    using System.Collections.Generic;

    public class RecruiterWithCandidatesServiceModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public int InterviewSlots { get; set; } = 5;

        public int ExperienceLevel { get; set; } = 1;

        public IEnumerable<RecruiterCandidateServiceModel> Candidates { get; set; }
    }
}
