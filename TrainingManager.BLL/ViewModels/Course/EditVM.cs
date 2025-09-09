using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TrainingManager.BLL.CustomValidators;

namespace TrainingManager.BLL.ViewModels.Course;

public class EditVM : BaseCourseVM
{
    public Guid Id { get; set; }

    [DisplayName("Course Name")]
    [Required(ErrorMessage = "course name is required")]
    [ClearFromDegets(ErrorMessage = "Course Name have to be clear from degits")]
    public string Name { get; set; } = string.Empty;
}
