using TrainingManager.BLL.Services.Interfaces;
using TrainingManager.BLL.ViewModels.Track;
using TrainingManager.DAL.Repositories.Interfaces;

namespace TrainingManager.BLL.Services
{
    public class TrackService(IUnitOfWork unitOfWork) : ITrackService
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;

        public async Task<IEnumerable<TrackVM>> GetAllAsync()
        {
            var tracks = await unitOfWork.Tracks.GetAllAsync();
            return tracks.Select(t => new TrackVM
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Duration_Weeks = t.Duration_Weeks,
            });
        }
    }
}
