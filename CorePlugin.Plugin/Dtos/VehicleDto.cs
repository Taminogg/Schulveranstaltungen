using System.ComponentModel.DataAnnotations;

namespace SYP_Schulveranstaltungen.Dtos
{
    public class VehicleDto
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
    }
}
