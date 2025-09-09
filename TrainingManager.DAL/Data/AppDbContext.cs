using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrainingManager.DAL.Models;
using TrainingManager.Models;

namespace TrainingManager.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Instructor> Instructors => Set<Instructor>();
    public DbSet<Trainee> Trainees => Set<Trainee>();
    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Session> Sessions => Set<Session>();
    public DbSet<TraineeSession> TraineeSessions => Set<TraineeSession>();



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        //modelBuilder.Entity<Instructor>().HasData(
        //    new Instructor
        //    {
        //        Id = Guid.Parse("12345678-1234-1234-1234-123456789abc"),
        //        FirstName = "Ahmed",
        //        LastName = "Ali",
        //        Bio = "Hi, this is my name",
        //        IsActive = true,
        //        Specialization = Specializations.SoftwareDevelopment
        //    },
        //    new Instructor
        //    {
        //        Id = Guid.Parse("12345678-1234-1234-1234-123456789aaa"),
        //        FirstName = "Sara",
        //        LastName = "Khan",
        //        Bio = "Experienced in digital marketing.",
        //        IsActive = true,
        //        Specialization = Specializations.Marketing
        //    });

        //modelBuilder.Entity<Course>().HasKey(c => c.Id);
        //modelBuilder.Entity<Course>().Property(x => x.Name).IsRequired();
        //modelBuilder.Entity<Course>().Property(x => x.Description).IsRequired();
        //modelBuilder.Entity<Course>().HasOne(c => c.Instructor).WithMany(i => i.Courses);
    }
}
