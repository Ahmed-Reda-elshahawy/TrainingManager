using TrainingManager.BLL.ViewModels.Track;

namespace TrainingManager.BLL.Services.Interfaces
{
    public interface ITrackService
    {
        Task<IEnumerable<TrackVM>> GetAllAsync();
    }
}
