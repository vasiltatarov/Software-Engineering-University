namespace TheRecrutmentTool.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Jobs;
    using ViewModels.Jobs;
    using static WebConstants;

    [ApiController]
    [Route("[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobs;

        public JobsController(IJobService jobs)
            => _jobs = jobs;

        [HttpPost]
        public JsonResult Post(JobFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(InvalidCreation);
            }

            _jobs.Create(model);

            return new JsonResult(AddedSuccessfully);
        }

        [HttpGet]
        public JsonResult Get(string skill)
            => new JsonResult(_jobs.GetBySkill(skill));

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            const string Job = "Job";

            var isEdited = _jobs.Delete(id);

            if (!isEdited)
            {
                return new JsonResult(string.Format(InvalidId, Job));
            }

            return new JsonResult(string.Format(DeletedSuccessfully, Job));
        }
    }
}
