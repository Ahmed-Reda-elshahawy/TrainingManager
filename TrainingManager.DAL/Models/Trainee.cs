namespace TrainingManager.DAL.Models
{
    public enum Tracks
    {
        FrontEnd,
        BackEnd,
        FullStack,
    }
    public class Trainee
    {
        public Guid Id { get; set; }
        public Tracks Track { get; set; }

        // navigation
        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;
        public virtual ICollection<TraineeSession> TraineeSessions { get; set; } = new HashSet<TraineeSession>();
    }
}
