using System.ComponentModel.DataAnnotations;
using TrainingManager.Models;

namespace TrainingManager.BLL.ViewModels.User
{
    public class RegisterInstructorVM : RegisterVM
    {
        [MaxLength(500)]
        public string Bio { get; set; } = string.Empty;
        public Specializations Specialization { get; set; }
    }
}
