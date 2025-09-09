using TrainingManager.Models;

namespace TrainingManager.DAL.Repositories.Interfaces
{
    public interface ICourseRepo : IGenericRepo<Course>
    {
        //IEnumerable<Course> GetAll();
        //Course? GetById(Guid id);
        Task<Course?> GetCourseWithInstructorAsync(Guid id);
        Task<bool> ISCourseNameExistsAsync(string name);
        //int GetCount(string? searchName = null);
        //IEnumerable<Course> GetPage(int page, int pageSize, string? searchName = null);
        //void Add(Course course);
        //void Update(Course course);
        //void Delete(Guid Id);
        //void Save();
    }
}
