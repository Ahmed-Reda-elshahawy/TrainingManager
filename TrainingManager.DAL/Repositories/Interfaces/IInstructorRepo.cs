using TrainingManager.Models;

namespace TrainingManager.DAL.Repositories.Interfaces
{
    public interface IInstructorRepo
    {
        IEnumerable<Instructor> GetAll();
        void Add(Instructor instructor);
        void Save();
    }
}
