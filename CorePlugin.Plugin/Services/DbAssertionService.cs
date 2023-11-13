using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolEventDbLib;
using System.Security.Claims;

namespace SYP_Schulveranstaltungen.Services
{
    public class DbAssertionService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public DbAssertionService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ExcursionContext>();

            db.Database.EnsureDeleted(); Console.WriteLine("Deleting database");
            db.Database.EnsureCreated(); Console.WriteLine("Creating database");
            Console.WriteLine("Database Ok");

            bool isDatabaseEmpty = !db.Vehicles.Any();
            if (isDatabaseEmpty)
            {
                PopulateVehicles(db);
            }


            //fillWithDummyData(db);

            return Task.CompletedTask;
        }

        private static void PopulateVehicles(ExcursionContext db)
        {
            Console.WriteLine("PopulateVehicles");
            var vehicle1 = new Vehicle { Name = "Bus" };
            var vehicle2 = new Vehicle { Name = "Zug" };
            var vehicle3 = new Vehicle { Name = "Flugzeug" };
            var vehicle4 = new Vehicle { Name = "Sonstiges" };
            db.Vehicles.Add(vehicle1);
            db.Vehicles.Add(vehicle2);
            db.Vehicles.Add(vehicle3);
            db.Vehicles.Add(vehicle4);
            db.SaveChanges();
        }

        public void fillWithDummyData(ExcursionContext db)
        {
            var teacher1 = new Teacher { Email = "test@gmx.at", Firstname = "Anton", Lastname = "Antoni" };
            db.Teachers.Add(teacher1);
            var teacher2 = new Teacher { Email = "test1@gmx.at", Firstname = "Maria", Lastname = "Balaa" };
            db.Teachers.Add(teacher2);

            var schoolClass1 = new SchoolClass { Name = "1A" };
            db.SchoolClasses.Add(schoolClass1);

            db.SaveChanges();

            var excursion1 = new Excursion
            {
                EndingDate = DateTime.Now,
                AddressOfDestination = "RomStraße 1",
                AddressOfSleepSite = "RomStraße100",
                ContactPersonOfDestination = "Anton Berger",
                Description = "Excursion um Museum zu sehen dort",
                StartingDate = DateTime.Now,
                PhoneNumberOfDestination = "132344232",
                IsApproved = false,
                LeadTeacher = teacher1,
                MeetingPoint = "Schule",
                NumberOfExcursionsThisYear = 1,
                NumberOfStudents = 23,
                PhoneNumberOfSleepSite = "123244245",
                ReasonForExcurion = "Museum passt thematisch zu Fach",
                AccompanyingTeacher = teacher2,
                SchoolClassId = 1,
                TeacherId = 1,
                SchoolClass = schoolClass1,
                AccompanyingTeacherId = 1
            };
            db.Excursions.Add(excursion1);

            var vehicle = db.Vehicles.Single(x => x.Id == 1);

            var hikingDay1 = new HikingDay
            {
                EndingDate = DateTime.Now,
                Description = "Excursion um Museum zu sehen dort",
                StartingDate = DateTime.Now,
                IsApproved = false,
                LeadTeacher = teacher1,
                MeetingPoint = "Schule",
                NumberOfStudents = 23,
                AccompanyingTeacher = teacher2,
                SchoolClassId = 1,
                TeacherId = 1,
                SchoolClass = schoolClass1,
                AccompanyingTeacherId = 1,
                Destination = "Rom",
                DistanceInKm = 1000,
                MarchingTimes = "21324 Stunden",
                PresumptiveCostsPerTeacher = 300,
                ReplacementProgram = "Wandern um die Schule",
                Vehicle = vehicle,
                VehicleId = 1,
            };
            db.HikingDays.Add(hikingDay1);

            db.SaveChanges();
        }
    }
}
