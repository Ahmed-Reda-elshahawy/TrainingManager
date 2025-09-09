using TrainingManager.DAL.Models;
using TrainingManager.Models;

namespace TrainingManager.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepo<Instructor> Instructors { get; }
        IGenericRepo<Trainee> Trainees { get; }
        IGenericRepo<Admin> Admins { get; }
        ICourseRepo Courses { get; }
        Task<int> CompleteAsync();
    }
}
