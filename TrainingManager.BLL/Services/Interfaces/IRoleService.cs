namespace TrainingManager.BLL.Services.Interfaces
{
    public interface IRoleService
    {
        Task<bool> EnsureRoleExistsAsync(string roleName);
        Task<bool> AssignRoleToUserAsync(Guid userId, string roleName);
        Task<bool> UserHasRoleAsync(Guid userId, string roleName);
    }
}
