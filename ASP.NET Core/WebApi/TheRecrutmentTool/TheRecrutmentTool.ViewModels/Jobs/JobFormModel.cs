namespace TheRecrutmentTool.ViewModels.Jobs
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static ViewModelsConstants.CreateJob;

    public class JobFormModel
    {
        [Required]
        [StringLength(TitleMaxLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        public string Description { get; set; }

        [Range(600, 150000)]
        public decimal Salary { get; set; }

        [Required, MinLength(2)]
        public IEnumerable<JobSkillInputModel> Skills { get; set; }
    }
}
