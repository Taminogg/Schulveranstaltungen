using SchoolEventDbLib;
using System.ComponentModel.DataAnnotations;

namespace SYP_Schulveranstaltungen.Dtos
{
    public class ExcursionDto
    {
        [Required] public int Id { get; set; }
        [Required] public bool IsApproved { get; set; }
        [Required] public string Description { get; set; } = null!;
        [Required] public DateTime StartingDate { get; set; }
        [Required] public DateTime EndingDate { get; set; }
        [Required] public int AccompanyingTeacherId { get; set; }
        [Required] public string MeetingPoint { get; set; } = null!;
        [Required] public string ReasonForExcurion { get; set; } = null!;
        [Required] public string AddressOfSleepSite { get; set; } = null!;
        [Required] public string PhoneNumberOfSleepSite { get; set; } = null!;
        [Required] public int NumberOfExcursionsThisYear { get; set; }
        [Required] public string PhoneNumberOfDestination { get; set; } = null!;
        [Required] public string AddressOfDestination { get; set; } = null!;
        [Required] public string ContactPersonOfDestination { get; set; } = null!;
        [Required] public int NumberOfStudents { get; set; }
        [Required] public int SchoolClassId { get; set; }
        [Required] public int TeacherId { get; set; }
    }
}
