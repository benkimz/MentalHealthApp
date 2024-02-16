using MentalHealthApp.PWA.Data.Models;

namespace MentalHealthApp.PWA.Data.Interfaces
{
    public interface IVideoContentService
    {
        Task<IEnumerable<VideoContent>?> GetAngerVideos();

        Task<IEnumerable<VideoContent>?> GetAnxietyVideos();

        Task<IEnumerable<VideoContent>?> GetDepressionVideos();

        Task<IEnumerable<VideoContent>?> GetGuiltVideos();
    }
}
