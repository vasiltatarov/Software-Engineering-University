namespace TheRecrutmentTool.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Recruiters;

    [ApiController]
    [Route("[controller]")]
    public class RecruitersController : ControllerBase
    {
        private readonly IRecruiterService _recruiters;

        public RecruitersController(IRecruiterService recruiters)
            => _recruiters = recruiters;

        [HttpGet]
        public JsonResult Get()
            => new JsonResult(_recruiters.GetAllWithAvailableCandidates());

        [HttpGet("{level}")]
        public JsonResult Get(int level)
            => new JsonResult(_recruiters.GetAllByLevel(level));
    }
}
