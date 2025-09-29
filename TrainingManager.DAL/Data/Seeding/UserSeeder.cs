using Microsoft.AspNetCore.Identity;
using TrainingManager.DAL.Models;
using TrainingManager.DAL.Repositories.Interfaces;

namespace TrainingManager.DAL.Data.Seeding
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager, IUnitOfWork unitOfWork)
        {
            string adminEmail = "AdminTMS@gmail.com";
            string adminPassword = "AdminTMS@1";
            var existingUser = await userManager.FindByEmailAsync(adminEmail);
            
            if (existingUser == null) {
                var user = new ApplicationUser
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = adminEmail,
                    UserName = adminEmail
                };
                var result = await userManager.CreateAsync(user, adminPassword);
                if(result.Succeeded)
                {
                    // Ensure role exists
                    if(!await roleManager.RoleExistsAsync(AppRoles.Admin.ToString()))
                    {
                        await roleManager.CreateAsync(new IdentityRole<Guid>(AppRoles.Admin.ToString()));
                    }

                    // Assign role
                    await userManager.AddToRoleAsync(user, AppRoles.Admin.ToString());

                    // Add Admin entity
                    var adminEntity = new Admin
                    {
                        Id = Guid.NewGuid(),
                        UserId = user.Id,
                    };
                    await unitOfWork.Admins.AddAsync(adminEntity);
                    await unitOfWork.CompleteAsync();
                }
            }
        }
    }
}
