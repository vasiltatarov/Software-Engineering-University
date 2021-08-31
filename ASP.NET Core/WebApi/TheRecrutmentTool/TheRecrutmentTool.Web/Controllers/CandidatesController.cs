namespace TheRecrutmentTool.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Candidates;
    using ViewModels.Candidates;
    using static WebConstants;

    [ApiController]
    [Route("[controller]")]
    public class CandidatesController : ControllerBase
    {
        private const string Candidate = "Candidate";

        private readonly ICandidateService _candidates;

        public CandidatesController(ICandidateService candidates)
            => _candidates = candidates;

        [HttpGet]
        public JsonResult Get()
            => new JsonResult(_candidates.GetAll());

        [HttpGet("{id}")]
        public JsonResult Get(int id)
            => new JsonResult(_candidates.GetById(id));

        [HttpPost]
        public JsonResult Post(CreateCandidateFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(InvalidCreation);
            }

            _candidates.Create(model);

            return new JsonResult(AddedSuccessfully);
        }

        [HttpPut("{id}")]
        public JsonResult Put(int id, CreateCandidateFormModel model)
        {
            var isEdited = _candidates.EditById(id, model);

            if (!isEdited)
            {
                return new JsonResult(string.Format(InvalidId, Candidate));
            }

            return new JsonResult(string.Format(EditedSuccessfully, Candidate));
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var isEdited = _candidates.DeleteById(id);

            if (!isEdited)
            {
                return new JsonResult(string.Format(InvalidId, Candidate));
            }

            return new JsonResult(string.Format(DeletedSuccessfully, Candidate));
        }
    }
}
