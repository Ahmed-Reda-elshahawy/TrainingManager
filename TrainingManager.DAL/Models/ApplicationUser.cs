using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TrainingManager.Models;

namespace TrainingManager.DAL.Models
{
    public enum AppRoles
    {
        Admin,
        Instructor,
        Trainee
    }

    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual Instructor? InstructorProfile { get; set; }
        public virtual Trainee? TraineeProfile { get; set; }
        public virtual Admin? AdminProfile { get; set; }
    }
}
