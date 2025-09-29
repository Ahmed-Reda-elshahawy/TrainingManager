using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TrainingManager.DAL.Models;
using TrainingManager.DAL.Repositories;
using TrainingManager.DAL.Repositories.Interfaces;

namespace TrainingManager.DAL.Data.Seeding
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            await RoleSeeder.SeedAsync(roleManager);
            await UserSeeder.SeedAsync(userManager, roleManager, unitOfWork);
        }
    }
}
