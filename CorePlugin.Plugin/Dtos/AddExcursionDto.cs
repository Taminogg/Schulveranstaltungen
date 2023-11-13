using SchoolEventDbLib;
using System.ComponentModel.DataAnnotations;

namespace SYP_Schulveranstaltungen.Dtos
{
    public class AddExcursionDto
    {
        [Required] public bool IsApproved { get; set; }
        [Required] public string Description { get; set; }
        [Required] public DateTime StartingDate { get; set; }
        [Required] public DateTime EndingDate { get; set; }
        [Required] public int AccompanyingTeacherId { get; set; }
        [Required] public string MeetingPoint { get; set; }
        [Required] public string ReasonForExcurion { get; set; }
        [Required] public string AddressOfSleepSite { get; set; }
        [Required] public string PhoneNumberOfSleepSite { get; set; }
        [Required] public int NumberOfExcursionsThisYear { get; set; }
        [Required] public string PhoneNumberOfDestination { get; set; }
        [Required] public string AddressOfDestination { get; set; }
        [Required] public string ContactPersonOfDestination { get; set; }
        [Required] public int NumberOfStudents { get; set; }
        [Required] public int SchoolClassId { get; set; }
        [Required] public int TeacherId { get; set; }
    }
}
