namespace TheRecrutmentTool.ViewModels.Candidates
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static ViewModelsConstants.CreateCandidate;

    public class CreateCandidateFormModel
    {
        [Required]
        [StringLength(FirstNameMaxLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(LastNameMaxLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = LastNameMinLength)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(BiographyMaxLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = BiographyMinLength)]
        public string Biography { get; set; }

        public DateTime Birthdate { get; set; }

        [Required, MinLength(2)]
        public ICollection<CandidateSkillInputModel> Skills { get; set; }
    }
}
