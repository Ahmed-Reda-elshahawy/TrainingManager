using TrainingManager.DAL.Models;
using TrainingManager.DAL.Repositories.Interfaces;
using TrainingManager.Data;
using TrainingManager.Models;

namespace TrainingManager.DAL.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext context = context;
        private IGenericRepo<Trainee>? trainees;
        private IGenericRepo<Instructor>? instructors;
        private IGenericRepo<Admin>? admins;
        private IGenericRepo<Track>? tracks;
        private ICourseRepo? courses;

        public IGenericRepo<Instructor> Instructors => instructors ??= new GenericRepo<Instructor>(context);
        public IGenericRepo<Trainee> Trainees => trainees ??= new GenericRepo<Trainee>(context);
        public IGenericRepo<Admin> Admins => admins ??= new GenericRepo<Admin>(context);
        public ICourseRepo Courses => courses ??= new CourseRepo(context);
        public IGenericRepo<Track> Tracks => tracks ??= new GenericRepo<Track>(context);

        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
