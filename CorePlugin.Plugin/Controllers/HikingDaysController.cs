using Microsoft.AspNetCore.Mvc;
using SYP_Schulveranstaltungen.Dtos;
using SYP_Schulveranstaltungen.Services;

namespace SYP_Schulveranstaltungen.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HikingDayController : Controller
    {
        private readonly DbService _dbService;
        public HikingDayController(DbService dbService) => _dbService = dbService;

        [HttpGet("GetAllHikingDays")]
        public List<HikingDayDto> GetAllHikingDays()
        {
            return _dbService.GetHikingDays().Select(x => new HikingDayDto().CopyFrom(x)).ToList();
        }

        [HttpGet("GetHikingDayWithDescription/{description}")]
        public List<HikingDayDto> GetHikingDayWithDescription(string description)
        {
            return _dbService.GetHikingDays().Select(x => new HikingDayDto().CopyFrom(x)).Where(x => x.Description.Contains(description)).ToList();
        }

        [HttpGet("GetHikingDaysOrderedByDate")]
        public List<HikingDayDto> GetHikingDaysOrderedByDate()
        {
            return _dbService.GetHikingDays().Select(x => new HikingDayDto().CopyFrom(x)).OrderBy(x=>x.StartingDate).ToList();
        }

        [HttpGet("GetHikingDayForTeacher/{id}")]
        public List<HikingDayDto> GetHikingDayForTeacher(int id)
        {
            return _dbService.GetHikingDays().Select(x => new HikingDayDto().CopyFrom(x)).Where(x => x.TeacherId == id).ToList();
        }

        [HttpPost("AddHikingDay")]
        public HikingDayDto AddHikingDay(AddHikingDayDto addHikingDayDto)
        {
            return _dbService.AddNewHikingDay(addHikingDayDto);
        }

        [HttpPut("EditHikingDay")]
        public HikingDayDto EditHikingDay(AddHikingDayDto addHikingDayDto)
        {
            return _dbService.AddNewHikingDay(addHikingDayDto);
        }

        [HttpPut("ApproveHikingDay")]
        public bool ApproveHikingDay(int id, bool approve)
        {
            return _dbService.ApproveHikingDay(id, approve);
        }
    }
}
