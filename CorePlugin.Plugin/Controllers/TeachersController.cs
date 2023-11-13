using Microsoft.AspNetCore.Mvc;
using SYP_Schulveranstaltungen.Dtos;
using SYP_Schulveranstaltungen.Services;

namespace SYP_Schulveranstaltungen.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly DbService _dbService;
        public TeacherController(DbService dbService) => _dbService = dbService;

        [HttpGet]
        public List<TeacherDto> GetAllTeachers(string namePart)
        {
            namePart = namePart.Trim().ToLower();
            bool useAll = namePart.Length == 0;
            return _dbService.GetTeachers()
            .Where(x => useAll || x.Lastname.ToLower().Contains(namePart))
            .Select(x => new TeacherDto().CopyFrom(x)).ToList();
        }

        //[HttpGet("{id}")]
        //public List<TeacherDto> GetTearchersByName(int id)
        //{
        //    return _dbService.GetTeachers()
        //    .Select(x => new TeacherDto
        //    {
        //        Email = x.Email,
        //        Firstname = x.FirstName,
        //        Lastname = x.Lastname,
        //        TeacherId = x.Id,
        //        FullName = x.FullName
        //    })
        //    .Where(x => x.FullName.Contains(filterString))
        //    .ToList();
        //}
    }
}
