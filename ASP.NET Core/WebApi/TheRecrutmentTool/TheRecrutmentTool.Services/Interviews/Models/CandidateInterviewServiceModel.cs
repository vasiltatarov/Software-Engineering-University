namespace TheRecrutmentTool.Services.Interviews.Models
{
    using System;

    public class CandidateInterviewServiceModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime Birthdate { get; set; }

        public string Biography { get; set; }

        public string Recruiter { get; set; }
    }
}
