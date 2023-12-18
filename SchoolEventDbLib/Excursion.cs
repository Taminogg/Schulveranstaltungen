using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEventDbLib;

public class Excursion
{
    public int Id { get; set; }
    public bool IsApproved { get; set; }
    public  string Description { get; set; } = null!;
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public int AccompanyingTeacherId { get; set; }
    public Teacher AccompanyingTeacher { get; set; } = null!;
    public  SchoolClass SchoolClass { get; set; } = null!;
    public  Teacher LeadTeacher { get; set; } = null!;
    public  string MeetingPoint { get; set; } = null!;
    public  string ReasonForExcurion { get; set; } = null!;
    public  string AddressOfSleepSite { get; set; } = null!;
    public  string PhoneNumberOfSleepSite { get; set; } = null!;
    public  int NumberOfExcursionsThisYear { get; set; }
    public  string PhoneNumberOfDestination { get; set; } = null!;
    public  string AddressOfDestination { get; set; } = null!;
    public  string ContactPersonOfDestination { get; set; } = null!;
    public int NumberOfStudents { get; set; }
    public int SchoolClassId { get; set; }
    public int TeacherId { get; set; }
}
