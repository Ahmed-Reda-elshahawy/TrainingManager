using System.ComponentModel.DataAnnotations;
using TrainingManager.DAL.Models;

namespace TrainingManager.Models
{
    public enum CourseCategory
    {
        Programming,
        Design,
        Marketing,
        Business
    }

    public class Course
    {
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;
        public CourseCategory Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        // navigation
        public Track? Track { get; set; }
        public Guid? TrackId { get; set; }
        public Instructor? Instructor { get; set; }
        public Guid? InstructorId { get; set; }
        public virtual ICollection<Session> Sessions { get; set; } = new HashSet<Session>();
    }
}
