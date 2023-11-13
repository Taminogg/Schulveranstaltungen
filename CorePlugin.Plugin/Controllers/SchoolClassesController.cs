using Microsoft.AspNetCore.Mvc;
using SYP_Schulveranstaltungen.Dtos;
using SYP_Schulveranstaltungen.Services;

namespace SYP_Schulveranstaltungen.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClazzController
    {
        private readonly DbService _dbService;
        public ClazzController(DbService dbService) => _dbService = dbService;

        [HttpGet]
        public List<SchoolClassDto> GetAllClasses()
        {
            return _dbService.GetAllSchoolClasses().Select(x => new SchoolClassDto().CopyFrom(x)).ToList();
        }
    }
}
