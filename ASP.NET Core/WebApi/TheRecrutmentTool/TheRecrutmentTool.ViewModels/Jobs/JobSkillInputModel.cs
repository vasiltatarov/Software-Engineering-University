﻿namespace TheRecrutmentTool.ViewModels.Jobs
{
    using System.ComponentModel.DataAnnotations;
    using static ViewModelsConstants.CreateJob;

    public class JobSkillInputModel
    {
        [Required]
        [StringLength(SkillNameMaxLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = SkillNameMinLength)]
        public string Name { get; set; }
    }
}
