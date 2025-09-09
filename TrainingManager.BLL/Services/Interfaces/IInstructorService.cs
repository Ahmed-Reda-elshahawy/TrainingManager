using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingManager.BLL.ViewModels.Instructor;

namespace TrainingManager.BLL.Services.Interfaces
{
    public interface IInstructorService
    {
        Task<IEnumerable<InstructorVM>> GetAllAsync();
        Task<IEnumerable<SelectListItem>> GetInstructorsSelectListAsync();
        Task AddAsync(CreateInstructorVM createInstructorVM);
    }
}
