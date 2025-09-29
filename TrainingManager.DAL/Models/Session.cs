using System.ComponentModel.DataAnnotations;
using TrainingManager.DAL.Models;

namespace TrainingManager.Models
{
    public class Session
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MaxTrainees { get; set; } = 20;
        public bool IsCompleted { get; set; } = false;

        // navigation
        public Guid? CourseId { get; set; }
        public virtual Course? Course { get; set; }
        public Guid? InstructorId { get; set; }
        public virtual Instructor? Instructor { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; } = new HashSet<Evaluation>();
    }
}
