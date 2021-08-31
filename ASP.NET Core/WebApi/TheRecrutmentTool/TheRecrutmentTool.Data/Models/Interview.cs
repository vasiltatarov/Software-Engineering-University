namespace TheRecrutmentTool.Data.Models
{
    using System;

    public class Interview
    {
        public int Id { get; set; }

        public int CandidateId { get; set; }

        public Candidate Candidate { get; set; }

        public int JobId { get; set; }

        public Job Job { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
