using SchoolEventDbLib;
using Microsoft.EntityFrameworkCore;

public class ExcursionContext : DbContext
{
    public ExcursionContext() { }
    public ExcursionContext(DbContextOptions<ExcursionContext> options) : base(options) { }

    public DbSet<SchoolClass> SchoolClasses { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Excursion> Excursions { get; set; }
    public DbSet<HikingDay> HikingDays { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        Console.WriteLine("OnConfiguring");
        //string connectionString = @"data source=C:\Users\gutja\Tamino\Programmieren\DB\Excursions.sqlite";
        string connectionString = @"Server=(LocalDB)\mssqllocaldb;attachdbfilename=C:\Users\gutja\Tamino\Programmieren\DB\Excursion.mdf;database=Excursion;integrated security=True;MultipleActiveResultSets=True";
        Console.WriteLine("connectionstring" + connectionString);
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Excursion>()
              .HasOne(e => e.LeadTeacher)
              .WithMany()
              .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Excursion>()
              .HasOne(e => e.AccompanyingTeacher)
              .WithMany()
              .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<HikingDay>()
              .HasOne(e => e.LeadTeacher)
              .WithMany()
              .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<HikingDay>()
               .HasOne(e => e.AccompanyingTeacher)
               .WithMany()
               .OnDelete(DeleteBehavior.NoAction);

    }
}
