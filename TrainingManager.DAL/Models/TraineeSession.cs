using TrainingManager.Models;

namespace TrainingManager.DAL.Models
{
    public class TraineeSession
    {
        public Guid? TraineeId { get; set; }
        public virtual Trainee? Trainee { get; set; }

        public Guid? SessionId { get; set; }
        public virtual Session? Session { get; set; }

        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
        public bool IsCompleted { get; set; } = false;
        public int? Grade { get; set; } // Out of 100
        public DateTime? CompletionDate { get; set; }
    }
}
