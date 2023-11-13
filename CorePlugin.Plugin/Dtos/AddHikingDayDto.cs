using SchoolEventDbLib;
using System.ComponentModel.DataAnnotations;

namespace SYP_Schulveranstaltungen.Dtos
{
    public class AddHikingDayDto
    {
        [Required] public bool IsApproved { get; set; }
        [Required] public string Description { get; set; }
        [Required] public bool HasTwoDays { get; set; }
        [Required] public DateTime StartingDate { get; set; }
        [Required] public DateTime EndingDate { get; set; }
        [Required] public int AccompanyingTeacherId { get; set; }
        [Required] public string MeetingPoint { get; set; }
        [Required] public string MarchingTimes { get; set; }
        [Required] public int NumberOfStudents { get; set; }
        [Required] public string Destination { get; set; }
        [Required] public string ReplacementProgram { get; set; }
        [Required] public float PresumptiveCostsPerTeacher { get; set; }
        [Required] public float DistanceInKm { get; set; }
        [Required] public int VehicleId { get; set; }
        [Required] public int TeacherId { get; set; }
        [Required] public int SchoolClassId { get; set; }
    }
}
