using Microsoft.AspNetCore.Mvc;
using SYP_Schulveranstaltungen.Dtos;
using SYP_Schulveranstaltungen.Services;

namespace SYP_Schulveranstaltungen.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExcurionController : Controller
    {
        private readonly DbService _dbService;
        public ExcurionController(DbService dbService) => _dbService = dbService;

        [HttpGet("GetAllExcursions")]
        public List<ExcursionDto> GetAllExcursions()
        {
            return _dbService.GetExcursions().Select(x => new ExcursionDto().CopyFrom(x)).ToList();
        }

        [HttpGet("GetExcursionWithDescription/{description}")]
        public List<ExcursionDto> GetExcursionWithDescription(string description)
        {
            return _dbService.GetHikingDays().Select(x => new ExcursionDto().CopyFrom(x)).Where(x => x.Description.Contains(description)).ToList();
        }

        [HttpGet("GetExcursionOrderedByDate")]
        public List<ExcursionDto> GetExcursionOrderedByDate()
        {
            return _dbService.GetHikingDays().Select(x => new ExcursionDto().CopyFrom(x)).OrderBy(x=>x.StartingDate).ToList();
        }

        [HttpGet("GetExcursionForTeacher/{id}")]
        public List<ExcursionDto> GetExcursionForTeacher(int id)
        {
            return _dbService.GetHikingDays().Select(x => new ExcursionDto().CopyFrom(x)).ToList();
        }

        [HttpPost("AddExcursion")]
        public ExcursionDto AddExcursion(AddExcursionDto addExcursionDto)
        {
            return _dbService.AddNewExcursion(addExcursionDto);
        }

        [HttpPut("EditExcursion")]
        public ExcursionDto EditExcursion(ExcursionDto editExcursion)
        {
            return _dbService.EditExcursion(editExcursion);
        }

        [HttpPut("ApproveExcursion")]
        public bool ApproveExcursion(int id, bool approve)
        {
            return _dbService.ApproveExcursion(id, approve);
        }
    }
}
