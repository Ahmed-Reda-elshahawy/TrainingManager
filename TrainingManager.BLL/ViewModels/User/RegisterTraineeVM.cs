using TrainingManager.DAL.Models;

namespace TrainingManager.BLL.ViewModels.User
{
    public class RegisterTraineeVM : RegisterVM
    {
        public Tracks Track { get; set; }
    }
}
