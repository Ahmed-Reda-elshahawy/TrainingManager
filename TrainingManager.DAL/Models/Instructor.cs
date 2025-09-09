using System.ComponentModel.DataAnnotations;
using TrainingManager.DAL.Models;

namespace TrainingManager.Models
{
    public enum Specializations
    {
        SoftwareDevelopment,
        Marketing,
        Business,
        Design,
    }

    public class Instructor
    {
        public Guid Id { get; set; }

        [MaxLength(500)]
        public string Bio { get; set; } = string.Empty;
        public decimal? HourlyRate { get; set; }
        public DateTime HiredDate { get; set; } = DateTime.UtcNow;
        public Specializations Specialization { get; set; }

        // navigation
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        public virtual ICollection<Session> Sessions { get; set; } = new HashSet<Session>();
    }

}
