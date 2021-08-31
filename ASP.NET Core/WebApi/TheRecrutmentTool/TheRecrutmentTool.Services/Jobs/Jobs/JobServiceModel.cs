namespace TheRecrutmentTool.Services.Jobs.Jobs
{
    using System.Collections.Generic;
    using Skills.Models;

    public class JobServiceModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Salary { get; set; }

        public IEnumerable<SkillServiceModel> Skills { get; set; }
    }
}
