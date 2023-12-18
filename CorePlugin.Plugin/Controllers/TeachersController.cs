using Microsoft.AspNetCore.Mvc;
using SYP_Schulveranstaltungen.Dtos;
using SYP_Schulveranstaltungen.Services;

namespace SYP_Schulveranstaltungen.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeachersController : Controller
    {
        private readonly DbService _dbService;
        public TeachersController(DbService dbService) => _dbService = dbService;

        [HttpGet]
        public List<TeacherDto> GetAllTeachers()
        {
            return _dbService.GetTeachers()
            .Select(x => new TeacherDto().CopyFrom(x)).ToList();
        }

        [HttpGet("GetTeacherForNamePart")]
        public List<TeacherDto> GetTeacherForNamePart(string namePart)
        {
            namePart = namePart.Trim().ToLower();
            Console.Write(namePart);
            bool useAll = namePart.Length == 0;
            Console.Write(useAll);
            return _dbService.GetTeachers()
            .Where(x => useAll || x.Lastname.ToLower().Contains(namePart))
            .Select(x => new TeacherDto().CopyFrom(x)).ToList();
        }
    }
}
