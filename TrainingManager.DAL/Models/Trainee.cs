namespace TrainingManager.DAL.Models
{
    //public enum Tracks
    //{
    //    FrontEnd,
    //    BackEnd,
    //    FullStack,
    //}
    public class Trainee
    {
        public Guid Id { get; set; }

        // navigation
        public Track? Track { get; set; }
        public Guid? TrackId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;
        public Guid UserId { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; } = new HashSet<Evaluation>();
    }
}
