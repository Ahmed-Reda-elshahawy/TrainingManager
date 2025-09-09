using System.Threading.Tasks;
using TrainingManager.BLL.Pagination;
using TrainingManager.BLL.Services.Interfaces;
using TrainingManager.BLL.ViewModels.Course;
using TrainingManager.DAL.Repositories.Interfaces;
using TrainingManager.Models;

namespace TrainingManager.BLL.Services
{
    public class CourseService(IUnitOfWork unitOfWork) : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<CourseVM>> GetAllAsync()
        {
            var courses = await _unitOfWork.Courses.GetAllAsync();
            return courses.Select(c => new CourseVM(c.Id, c.Name, c.Description, c.Category, c.StartDate, c.EndDate, c.IsActive));
        }

        public async Task<CourseVM?> GetByIdAsync(Guid id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            if (course == null) return null;
            return new CourseVM(course.Id, course.Name, course.Description, course.Category, course.StartDate, course.EndDate, course.IsActive);
        }

        public async Task<DetailsVM?> GetDetailsAsync(Guid id)
        {
            var course = await _unitOfWork.Courses.GetCourseWithInstructorAsync(id);
            if (course == null) return null;
            return new DetailsVM(course.Id, course.Name, course.Description, course?.Instructor?.User.FirstName + " " + course?.Instructor?.User.LastName);
        }

        public async Task<EditVM?> GetCourseToEditAsync(Guid id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            if (course == null) return null;

            var editCourseVM = new EditVM()
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Category = course.Category,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                IsActive = course.IsActive,
                InstructorId = course.InstructorId,
            };

            return editCourseVM;
        }

        public async Task<PagedResult<CourseVM>> GetPagedAsync(int page, int pageSize)
        {
            var courses = await _unitOfWork.Courses.GetPageAsync(page, pageSize);
            var items = courses.Select(c => new CourseVM(c.Id, c.Name, c.Description, c.Category, c.StartDate, c.EndDate, c.IsActive));
            //var totalCount = courseRepo.GetCount(searchName);

            return new PagedResult<CourseVM>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = await _unitOfWork.Courses.CountAsync()
            };
        }

        public async Task<bool> ISCourseNameExistsAsync(string name)
        {
            return await _unitOfWork.Courses.ISCourseNameExistsAsync(name);
        }

        public async Task AddAsync(CreateVM createCourseVM)
        {
            var course = new Course()
            {
                Id = Guid.NewGuid(),
                Name = createCourseVM.Name,
                Description = createCourseVM.Description,
                Category = createCourseVM.Category,
                StartDate = createCourseVM.StartDate,
                EndDate = createCourseVM.EndDate,
                IsActive = createCourseVM.IsActive,
                InstructorId = createCourseVM.InstructorId,
            };

            await _unitOfWork.Courses.AddAsync(course);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(EditVM editCourseVM)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(editCourseVM.Id);
            if (course == null) return;

            course.Id = editCourseVM.Id;
            course.Name = editCourseVM.Name;
            course.Description = editCourseVM.Description;
            course.Category = editCourseVM.Category;
            course.StartDate = editCourseVM.StartDate;
            course.EndDate = editCourseVM.EndDate;
            course.IsActive = editCourseVM.IsActive;
            course.InstructorId = editCourseVM.InstructorId;

            await _unitOfWork.Courses.UpdateAsync(course);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            if (course == null) return false;

            await _unitOfWork.Courses.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return true;
        }

    }
}
