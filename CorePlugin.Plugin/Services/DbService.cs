using SchoolEventDbLib;
using SYP_Schulveranstaltungen.Dtos;

namespace SYP_Schulveranstaltungen.Services
{
    public class DbService
    {
        private readonly ExcursionContext _db;
        public DbService(ExcursionContext db) => _db = db;

        internal List<Teacher> GetTeachers()
        {
            return _db.Teachers.ToList();
        }

        internal List<SchoolClass> GetAllSchoolClasses()
        {
            return _db.SchoolClasses.ToList();
        }

        internal List<Vehicle> GetVehicles()
        {
            return _db.Vehicles.ToList();
        }

        internal List<HikingDay> GetHikingDays()
        {
            return _db.HikingDays.ToList();
        }

        internal List<Excursion> GetExcursions()
        {
            return _db.Excursions.ToList();
        }

        internal HikingDayDto AddNewHikingDay(AddHikingDayDto addHikingDayDto)
        {
            try
            {
                var schoolClass = _db.SchoolClasses.Single(x => x.Id == addHikingDayDto.SchoolClassId);
                var leadTeacher = _db.Teachers.Single(x => x.Id == addHikingDayDto.TeacherId);
                var accompanyingTeacher = _db.Teachers.Single(x => addHikingDayDto.AccompanyingTeacherId == x.Id);
                var vehicle = _db.Vehicles.Single(x => x.Id == addHikingDayDto.VehicleId);

                var hikingDay = new HikingDay
                {
                    Description = addHikingDayDto.Description,
                    Destination = addHikingDayDto.Destination,
                    EndingDate = addHikingDayDto.EndingDate,
                    HasTwoDays = addHikingDayDto.HasTwoDays,
                    DistanceInKm = addHikingDayDto.DistanceInKm,
                    StartingDate = addHikingDayDto.StartingDate,
                    AccompanyingTeacher = accompanyingTeacher,
                    AccompanyingTeacherId = addHikingDayDto.AccompanyingTeacherId,
                    SchoolClass = schoolClass,
                    IsApproved = addHikingDayDto.IsApproved,
                    LeadTeacher = leadTeacher,
                    MarchingTimes = addHikingDayDto.MarchingTimes,
                    MeetingPoint = addHikingDayDto.MeetingPoint,
                    NumberOfStudents = addHikingDayDto.NumberOfStudents,
                    PresumptiveCostsPerTeacher = addHikingDayDto.PresumptiveCostsPerTeacher,
                    ReplacementProgram = addHikingDayDto.ReplacementProgram,
                    SchoolClassId = addHikingDayDto.SchoolClassId,
                    TeacherId = addHikingDayDto.TeacherId,
                    Vehicle = vehicle,
                    VehicleId = addHikingDayDto.VehicleId
                };

                _db.HikingDays.Add(hikingDay);
                _db.SaveChanges();

                var hikingDayDto = new HikingDayDto().CopyFrom(hikingDay);

                return hikingDayDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }            
        }

        internal HikingDayDto EditHikingDay(HikingDayDto hikingDayDto)
        {
            try
            {
                var schoolClass = _db.SchoolClasses.Single(x => x.Id == hikingDayDto.SchoolClassId);
                var leadTeacher = _db.Teachers.Single(x => x.Id == hikingDayDto.TeacherId);
                var vehicle = _db.Vehicles.Single(x => x.Id == hikingDayDto.VehicleId);

                var hikingDay = _db.HikingDays.Single(x => x.Id == hikingDayDto.Id);
                hikingDay.HasTwoDays = hikingDayDto.HasTwoDays;
                hikingDay.Description = hikingDay.Description;
                hikingDay.Destination = hikingDayDto.Destination;
                hikingDay.DistanceInKm = hikingDayDto.DistanceInKm;
                hikingDay.EndingDate = hikingDayDto.EndingDate;
                hikingDay.StartingDate = hikingDayDto.StartingDate;
                hikingDay.SchoolClass = schoolClass;
                hikingDay.IsApproved = hikingDayDto.IsApproved;
                hikingDay.LeadTeacher = leadTeacher;
                hikingDay.MarchingTimes = hikingDayDto.MarchingTimes;
                hikingDay.MeetingPoint = hikingDayDto.MeetingPoint;
                hikingDay.NumberOfStudents = hikingDayDto.NumberOfStudents;
                hikingDay.PresumptiveCostsPerTeacher = hikingDayDto.PresumptiveCostsPerTeacher;
                hikingDay.ReplacementProgram = hikingDayDto.ReplacementProgram;
                hikingDay.AccompanyingTeacherId = hikingDayDto.AccompanyingTeacherId;
                hikingDay.Vehicle = vehicle;
                hikingDay.TeacherId = hikingDayDto.TeacherId;
                hikingDay.VehicleId = hikingDayDto.VehicleId;
                hikingDay.SchoolClassId = hikingDayDto.SchoolClassId;

                _db.HikingDays.Add(hikingDay);
                _db.SaveChanges();

                var returnHikingDayDto = new HikingDayDto().CopyFrom(hikingDay);

                return returnHikingDayDto;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        internal bool ApproveHikingDay(int id, bool approved)
        {
            try
            {
                var hikingDay = _db.HikingDays.Single(x => x.Id == id);
                hikingDay.IsApproved = approved;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            } 
        }

        internal ExcursionDto AddNewExcursion(AddExcursionDto addExcursionDto)
        {
            try
            {
                var schoolClass = _db.SchoolClasses.Single(x => x.Id == addExcursionDto.SchoolClassId);
                var leadTeacher = _db.Teachers.Single(x => x.Id == addExcursionDto.TeacherId);
                var accompanyingTeacher = _db.Teachers.Single(x => addExcursionDto.AccompanyingTeacherId == x.Id);

                var excursion = new Excursion
                {
                    Description = addExcursionDto.Description,
                    ContactPersonOfDestination = addExcursionDto.ContactPersonOfDestination,
                    AddressOfDestination = addExcursionDto.AddressOfDestination,
                    EndingDate = addExcursionDto.EndingDate,
                    PhoneNumberOfDestination = addExcursionDto.PhoneNumberOfDestination,
                    StartingDate = addExcursionDto.StartingDate,
                    AccompanyingTeacher = accompanyingTeacher,
                    AccompanyingTeacherId = addExcursionDto.AccompanyingTeacherId,
                    AddressOfSleepSite = addExcursionDto.AddressOfSleepSite,
                    SchoolClass = schoolClass,
                    IsApproved = addExcursionDto.IsApproved,
                    LeadTeacher = leadTeacher,
                    MeetingPoint = addExcursionDto.MeetingPoint,
                    NumberOfExcursionsThisYear = addExcursionDto.NumberOfExcursionsThisYear,
                    NumberOfStudents = addExcursionDto.NumberOfStudents,
                    PhoneNumberOfSleepSite = addExcursionDto.PhoneNumberOfSleepSite,
                    ReasonForExcurion = addExcursionDto.ReasonForExcurion,
                    SchoolClassId = addExcursionDto.SchoolClassId,
                    TeacherId = addExcursionDto.TeacherId
                };

                _db.Excursions.Add(excursion);
                _db.SaveChanges();

                var excursionDto = new ExcursionDto().CopyFrom(excursion);

                return excursionDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        internal ExcursionDto EditExcursion(ExcursionDto excursionDto)
        {
            try
            {
                var schoolClass = _db.SchoolClasses.Single(x => x.Id == excursionDto.SchoolClassId);
                var leadTeacher = _db.Teachers.Single(x => x.Id == excursionDto.TeacherId);
                var teachers = _db.Teachers.Where(x => excursionDto.AccompanyingTeacherId == x.Id).ToList();

                var excursion = _db.Excursions.Single(x => x.Id == excursionDto.Id);
                excursion.Description = excursionDto.Description;
                excursion.SchoolClass = schoolClass;
                excursion.IsApproved = excursionDto.IsApproved;
                excursion.LeadTeacher = leadTeacher;
                excursion.MeetingPoint = excursionDto.MeetingPoint;
                excursion.NumberOfStudents = excursionDto.NumberOfStudents;
                excursion.AccompanyingTeacherId = excursionDto.AccompanyingTeacherId;
                excursion.TeacherId = excursionDto.TeacherId;
                excursion.SchoolClassId = excursionDto.SchoolClassId;
                excursion.AddressOfDestination = excursionDto.AddressOfDestination;
                excursion.EndingDate = excursionDto.EndingDate;
                excursion.StartingDate = excursionDto.StartingDate;
                excursion.ContactPersonOfDestination = excursionDto.ContactPersonOfDestination;
                excursion.PhoneNumberOfDestination = excursionDto.PhoneNumberOfDestination;
                excursion.AddressOfSleepSite = excursionDto.AddressOfSleepSite;
                excursion.ReasonForExcurion = excursionDto.ReasonForExcurion;
                excursion.PhoneNumberOfSleepSite = excursionDto.PhoneNumberOfSleepSite;
                excursion.NumberOfExcursionsThisYear = excursionDto.NumberOfExcursionsThisYear;

                _db.Excursions.Add(excursion);
                _db.SaveChanges();

                var returnExcursionDto = new ExcursionDto().CopyFrom(excursion);

                return returnExcursionDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        internal bool ApproveExcursion(int id, bool approved)
        {
            try
            {
                var excursion = _db.Excursions.Single(x => x.Id == id);
                excursion.IsApproved = approved;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
