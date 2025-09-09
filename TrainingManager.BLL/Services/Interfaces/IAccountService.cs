using Microsoft.AspNetCore.Identity;
using TrainingManager.BLL.ViewModels.User;
using TrainingManager.DAL.Models;

namespace TrainingManager.BLL.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterTraineeAsync(RegisterTraineeVM model);
        Task<IdentityResult> RegisterInstructorAsync(RegisterInstructorVM model);
        Task<IdentityResult> RegisterAdminAsync(RegisterAdminVM model);
        Task<SignInResult> LoginAsync(LoginVM model);
        Task LogoutAsync();
        Task AddClaimsAsync(ApplicationUser user);
    }
}
