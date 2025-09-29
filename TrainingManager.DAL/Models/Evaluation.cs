using TrainingManager.Models;

namespace TrainingManager.DAL.Models
{
    public class Evaluation
    {
        public int Score {  get; set; }

        // navigation
        public Guid? TraineeId { get; set; }
        public virtual Trainee? Trainee { get; set; }

        public Guid? SessionId { get; set; }
        public virtual Session? Session { get; set; }

        public Guid? InstructorId { get; set; }
        public virtual Instructor? Instructor { get; set; }
    }
}
