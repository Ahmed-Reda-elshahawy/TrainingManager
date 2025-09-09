using System.ComponentModel.DataAnnotations;
using TrainingManager.Models;

namespace TrainingManager.BLL.ViewModels.Course
{
    public class BaseCourseVM
    {
        [MaxLength(100, ErrorMessage = "the length have to be less that 100 character")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required")]
        public CourseCategory Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Instructor is required")]
        public Guid? InstructorId { get; set; }
    }
}
