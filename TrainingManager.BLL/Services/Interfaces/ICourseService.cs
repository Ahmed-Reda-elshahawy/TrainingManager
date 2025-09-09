using TrainingManager.BLL.Pagination;
using TrainingManager.BLL.ViewModels.Course;

namespace TrainingManager.BLL.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseVM>> GetAllAsync();
        Task<CourseVM?> GetByIdAsync(Guid id);
        Task<DetailsVM?> GetDetailsAsync(Guid id);
        Task<EditVM?> GetCourseToEditAsync(Guid id);
        //Task<PagedResult<CourseVM>> GetPagedAsync(int page, int pageSize, string? searchName);
        Task<PagedResult<CourseVM>> GetPagedAsync(int page, int pageSize);
        Task<bool> ISCourseNameExistsAsync(string name);
        Task AddAsync(CreateVM createCourseVM);
        Task UpdateAsync(EditVM editCourseVM);
        Task<bool> DeleteAsync(Guid id);
    }
}
