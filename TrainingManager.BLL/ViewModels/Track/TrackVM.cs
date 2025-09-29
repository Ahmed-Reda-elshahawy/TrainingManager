namespace TrainingManager.BLL.ViewModels.Track
{
    public class TrackVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Duration_Weeks { get; set; }
    }
}
