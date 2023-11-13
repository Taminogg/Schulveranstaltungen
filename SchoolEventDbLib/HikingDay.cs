using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEventDbLib
{
    public class HikingDay
    {
        public int Id { get; set; }
        public bool IsApproved { get; set; }
        public bool HasTwoDays { get; set; }
        public string Description { get; set; } = null!;
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public Teacher AccompanyingTeacher { get; set; } = null!;
        public int AccompanyingTeacherId { get; set; }
        public SchoolClass SchoolClass { get; set; } = null!;
        public Teacher LeadTeacher { get; set; } = null!;
        public string MeetingPoint { get; set; } = null!;
        public string MarchingTimes { get; set; } = null!;
        public int NumberOfStudents { get; set; }
        public string Destination { get; set; } = null!;
        public string ReplacementProgram { get; set; } = null!;
        public float PresumptiveCostsPerTeacher { get; set; }
        public float DistanceInKm { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;
        public int TeacherId { get; set; }
        public int SchoolClassId { get; set; }
    }
}
