using System.ComponentModel.DataAnnotations;

namespace SYP_Schulveranstaltungen.Dtos
{
    public class SchoolClassDto
    {
        [Required] public int Id { get; set; }
        [Required] public string ClassName { get; set; }
    }
}
