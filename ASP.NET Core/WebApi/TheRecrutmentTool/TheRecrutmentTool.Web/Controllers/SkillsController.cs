namespace TheRecrutmentTool.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Skills;

    [ApiController]
    [Route("[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skills;

        public SkillsController(ISkillService skills)
            => _skills = skills;

        [HttpGet("{id}")]
        public JsonResult Get(int id)
            => new JsonResult(_skills.GetById(id));

        /// <summary>
        /// Sorry for this, but I don't understand requirements very well.
        /// </summary>
        /// <returns></returns>
        [HttpGet("active")]
        public JsonResult Get()
            => new JsonResult(_skills.GetByCandidate(5));
    }
}
