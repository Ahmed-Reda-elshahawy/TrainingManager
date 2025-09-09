using TrainingManager.Models;

namespace TrainingManager.BLL.ViewModels.Course;

public record CourseVM(Guid Id, string Name, string Description, CourseCategory Category, DateTime StartDate, DateTime EndDate, bool IsActive);
