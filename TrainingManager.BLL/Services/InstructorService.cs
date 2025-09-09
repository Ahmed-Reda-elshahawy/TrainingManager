using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using TrainingManager.BLL.Services.Interfaces;
using TrainingManager.BLL.ViewModels.Instructor;
using TrainingManager.DAL.Repositories.Interfaces;
using TrainingManager.Models;

namespace TrainingManager.BLL.Services
{
    public class InstructorService(IUnitOfWork unitOfWork) : IInstructorService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<InstructorVM>> GetAllAsync()
        {
            var instructors = await _unitOfWork.Instructors.GetAllAsync();
            return instructors.Select(i => new InstructorVM
            {
                FirstName = i.User.FirstName,
                LastName = i.User.LastName,
                IsActive = i.User.IsActive,
                Bio = i.Bio,
                Specialization = i.Specialization
            }).ToList();
        }

        public async Task<IEnumerable<SelectListItem>> GetInstructorsSelectListAsync()
        {
            var instructors = await _unitOfWork.Instructors.GetAllAsync();
            return instructors.Select(i => new SelectListItem(i.User.FirstName, i.Id.ToString()));
        }

        public async Task AddAsync(CreateInstructorVM createInstructorVM)
        {
            var instructor = new Instructor
            {
                Id = Guid.NewGuid(),
                Bio = createInstructorVM.Bio,
                Specialization = createInstructorVM.Specialization,
            };
            await _unitOfWork.Instructors.AddAsync(instructor);
            await _unitOfWork.CompleteAsync();
        }
    }
}
