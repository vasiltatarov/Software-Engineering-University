namespace TheRecrutmentTool.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Interviews;

    [ApiController]
    [Route("[controller]")]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewService _interviews;

        public InterviewsController(IInterviewService interviews)
            => _interviews = interviews;

        [HttpGet]
        public JsonResult Get()
            => new JsonResult(_interviews.GetAll());
    }
}
