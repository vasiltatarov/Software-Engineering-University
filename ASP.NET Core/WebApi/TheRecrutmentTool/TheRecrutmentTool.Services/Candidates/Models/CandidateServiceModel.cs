namespace TheRecrutmentTool.Services.Candidates.Models
{
    using System;
    using System.Collections.Generic;
    using TheRecrutmentTool.Services.Skills.Models;

    public class CandidateServiceModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Biography { get; set; }

        public DateTime Birthdate { get; set; }

        public CandidateRecruiterServiceModel Recruiter { get; set; }

        public IEnumerable<SkillServiceModel> Skills { get; set; }
    }
}
