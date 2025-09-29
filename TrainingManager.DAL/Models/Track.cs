using TrainingManager.Models;

namespace TrainingManager.DAL.Models
{
    public class Track
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Duration_Weeks { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        
        // navigation
        public Guid? AdminId { get; set; }
        public Admin? Admin { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        public virtual ICollection<Trainee> Trainees { get; set; } = new HashSet<Trainee>();
    }
}
