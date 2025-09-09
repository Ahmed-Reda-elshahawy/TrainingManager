using TrainingManager.DAL.Models;
using TrainingManager.Models;

namespace TrainingManager.BLL.ViewModels.Instructor
{
    public class InstructorVM
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public string? ImgUrl { get; set; } = string.Empty;
        public AppRoles Role { get; set; }
        public string Bio { get; set; } = string.Empty;
        public Specializations Specialization { get; set; }
    }
}
