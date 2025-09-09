using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TrainingManager.BLL.CustomValidators;

namespace TrainingManager.BLL.ViewModels.Course;

public class CreateVM : BaseCourseVM
{
    [DisplayName("Course Name")]
    [Required(ErrorMessage = "course name is required")]
    [Remote(action: "CheckForUniqueCourseName", controller: "Course")]
    [ClearFromDegets(ErrorMessage = "Course Name have to be clear from degits")]
    public string Name { get; set; } = string.Empty;
}
