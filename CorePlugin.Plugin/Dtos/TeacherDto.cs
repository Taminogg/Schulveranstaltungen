using System.ComponentModel.DataAnnotations;

namespace SYP_Schulveranstaltungen.Dtos;

public class TeacherDto
{
    [Required] public int Id { get; set; }
    [Required] public string Firstname { get; set; } = null!;
    [Required] public string Lastname { get; set; } = null!;
    [Required] public string Email { get; set; } = null!;
    [Required] public string Fullname => $"{Lastname}  {Firstname}";
}
