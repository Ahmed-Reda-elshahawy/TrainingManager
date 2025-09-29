using System.ComponentModel.DataAnnotations;
using TrainingManager.DAL.Models;

namespace TrainingManager.BLL.ViewModels.User
{
    public class RegisterTraineeVM : RegisterVM
    {
        [Required]
        [Display(Name ="Track")]
        public Guid TrackId { get; set; }
    }
}
