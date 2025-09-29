using Microsoft.AspNetCore.Identity;
using TrainingManager.BLL.Services.Interfaces;
using TrainingManager.DAL.Models;

namespace TrainingManager.BLL.Services
{
    public class RoleService(RoleManager<IdentityRole<Guid>> roleManager, UserManager<ApplicationUser> userManager) : IRoleService
    {
        private readonly RoleManager<IdentityRole<Guid>> _roleManager = roleManager;
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        public async Task<bool> EnsureRoleExistsAsync(string roleName)
        {
            if(!await _roleManager.RoleExistsAsync(roleName))
            {
                var result = await _roleManager.CreateAsync(new IdentityRole<Guid>(roleName));
                return result.Succeeded;
            }
            return true;
        }

        public async Task<bool> AssignRoleToUserAsync(Guid userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;

            await EnsureRoleExistsAsync(roleName);

            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
        }

        public async Task<bool> UserHasRoleAsync(Guid userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;

            return await _userManager.IsInRoleAsync(user, roleName);
        }
    }
}
