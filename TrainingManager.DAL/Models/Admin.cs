namespace TrainingManager.DAL.Models
{
    public class Admin
    {
        public Guid Id { get; set; }

        // navigation
        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;
        public virtual ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
    }
}
