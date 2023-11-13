using Microsoft.AspNetCore.Mvc;
using SYP_Schulveranstaltungen.Dtos;
using SYP_Schulveranstaltungen.Services;

namespace SYP_Schulveranstaltungen.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehiclesController : Controller
    {
        private readonly DbService _dbService;
        public VehiclesController(DbService dbService) => _dbService = dbService;

        [HttpGet]
        public List<VehicleDto> GetAllVehicles()
        {
            return _dbService.GetVeicles().Select(x => new VehicleDto
            {
                Id = x.Id,
                VehicleName = x.Name
            }).ToList();
        }
    }
}
