using Microsoft.AspNetCore.Identity;
using TrainingManager.DAL.Models;

namespace TrainingManager.DAL.Data.Seeding
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<IdentityRole<Guid>> roleManager)
        {
            var roles = new[] { "Admin", "Instructor", "Trainee" };
            foreach (var roleName in roles)
            {
                if(!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole<Guid>(roleName));
                }
            }
        }
    }
}
