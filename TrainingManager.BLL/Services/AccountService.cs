using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TrainingManager.BLL.Services.Interfaces;
using TrainingManager.BLL.ViewModels.User;
using TrainingManager.DAL.Models;
using TrainingManager.DAL.Repositories.Interfaces;
using TrainingManager.Models;

namespace TrainingManager.BLL.Services
{
    public class AccountService
        (
        UserManager<ApplicationUser> userManager, 
        SignInManager<ApplicationUser> signInManager, 
        IUnitOfWork unitOfWork,
        IRoleService roleService
        ) : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IRoleService _roleService = roleService;

        public async Task<IdentityResult> RegisterAdminAsync(RegisterAdminVM model)
        {
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };
            
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _roleService.AssignRoleToUserAsync(user.Id, "Admin");
                await AddClaimsAsync(user);

                var admin = new Admin
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                };
                await _unitOfWork.Admins.AddAsync(admin);
                await _unitOfWork.CompleteAsync();
            }

            return result;
        }

        public async Task<IdentityResult> RegisterInstructorAsync(RegisterInstructorVM model)
        {
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _roleService.AssignRoleToUserAsync(user.Id, "Instructor");
                await AddClaimsAsync(user);

                var instructor = new Instructor
                {
                    Id = Guid.NewGuid(),
                    Bio = model.Bio,
                    HourlyRate = 100,
                    Specialization = model.Specialization,
                    UserId = user.Id,
                };
                await _unitOfWork.Instructors.AddAsync(instructor);
                await _unitOfWork.CompleteAsync();
            }

            return result;
        }

        public async Task<IdentityResult> RegisterTraineeAsync(RegisterTraineeVM model)
        {
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if(result.Succeeded)
            {
                await _roleService.AssignRoleToUserAsync(user.Id, "Trainee");
                await AddClaimsAsync(user);

                var trainee = new Trainee
                {
                    Id= Guid.NewGuid(),
                    TrackId = model.TrackId,
                    UserId = user.Id
                };
                await _unitOfWork.Trainees.AddAsync(trainee);
                await _unitOfWork.CompleteAsync();
            }

            return result;
        }

        public async Task<SignInResult> LoginAsync(LoginVM model)
        {
            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task AddClaimsAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Role, (await _userManager.GetRolesAsync(user)).FirstOrDefault() ?? "Trainee"),
                new Claim("FullName", $"{user.FirstName} {user.LastName}")
            };

            var existingClaims = await _userManager.GetClaimsAsync(user);
            foreach(var claim in claims)
            {
                if (!existingClaims.Any(c => c.Type == claim.Type && c.Value == claim.Value))
                {
                    await _userManager.AddClaimAsync(user, claim);
                }
            }
        }
    }
}
