using MentalHealthApp.PWA.Data.Context.Entities;
using MentalHealthApp.PWA.Data.Enums;

namespace MentalHealthApp.PWA.Data.Context.Interfaces
{
    public interface IVideoContentRepository
    {
        Task<Video?> CreateVideo(string creatorId, ContentCategory category, int step, string videoUrl, string? title = null, string? body = null, string? textPrompts = null, string? pdfUrl = null, string? videoName = null);

        Task<Video?> DeleteVideo(int videoId);

        Task<UserEmotionLog?> AddEmotionLog(string userId, int videoId, ContentCategory contentCategory, string promptKey, string content);
        Task<UserEmotionLog?> DeleteEmotionLog(int logId);
        Task<UserEmotionLog?> GetEmotionLog(int logId);
        Task<IEnumerable<UserEmotionLog>?> GetUserEmotionLogs(string userId);
        Task<List<Dictionary<string, UserEmotionLog>>?> GetUserEmotionLogsByCategory(string userId, ContentCategory contentCategory);
        Task<IEnumerable<UserEmotionLog?>?> GetLastUserEmotionLogsPerCategory(string userId);
        Task<List<Dictionary<string, UserEmotionLog>>?> GetDefaultHistory(string userId);

        Task<List<Dictionary<UserEmotionLog, string>>?> TestQuery(string userId, ContentCategory contentCategory); // ~
        Task<UserEmotionLog?> UpdateEmotionLog(string userId, int logId, string content);


        // ~ getter methods
        Task<IEnumerable<Video>?> GetAllVideos();

        Task<IEnumerable<Video>?> GetAngerVideos();

        Task<IEnumerable<Video>?> GetAnxietyVideos();

        Task<IEnumerable<Video>?> GetDepressionVideos();

        Task<IEnumerable<Video>?> GetGuiltVideos();

        Task<IEnumerable<Video>?> GetABCVideos();
    }
}
