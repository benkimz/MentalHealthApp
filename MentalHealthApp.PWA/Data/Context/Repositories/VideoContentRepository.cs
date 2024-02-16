using System.Text.Json;
using MentalHealthApp.PWA.Data.Context.Entities;
using MentalHealthApp.PWA.Data.Context.Interfaces;
using MentalHealthApp.PWA.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace MentalHealthApp.PWA.Data.Context.Repositories
{
    public class VideoContentRepository : IVideoContentRepository
    {
        private readonly AppDbContext _context;

        public VideoContentRepository(AppDbContext context)
        {
            _context = context;
        }

        private IQueryable<Video> IncludeVideoRelations()
        {
            return _context.Videos
                .AsQueryable();//.Include(v => v.EmotionLogs);
        }

        public async Task<UserEmotionLog?> AddEmotionLog(string userId, int videoId, ContentCategory contentCategory, string promptKey, string content)
        {
            // Console.WriteLine($">>>> BACKEND: prompt: {promptKey}, user: {userId}, content: {content}, cat: {contentCategory.ToString()} video: {videoId}"); //////
            if (ValidString(promptKey) && ValidString(userId) && ValidString(content) && videoId > 0)
            {
                UserEmotionLog log = new UserEmotionLog
                {
                    VideoId = videoId,
                    VideoCategory = contentCategory,
                    PromptKey = promptKey,
                    UserId = userId,
                    Content = content,
                    CreatedDateTimeUTC = DateTime.UtcNow
                };
                var results = await _context.UserEmotionLogs.AddAsync(log);
                await _context.SaveChangesAsync();
                return results.Entity;
            }
            return null;
        }

        public Task<UserEmotionLog?> DeleteEmotionLog(int logId)
        {
            var log = _context.UserEmotionLogs.Find(logId);
            if (log is not null)
            {
                var res = _context.UserEmotionLogs.Remove(log);
                _context.SaveChanges();
                return Task.FromResult(res.Entity ?? null);
            }
            return Task.FromResult<UserEmotionLog?>(null);
        }

        public Task<UserEmotionLog?> GetEmotionLog(int logId)
        {
            return Task.FromResult(_context.UserEmotionLogs.Find(logId) ?? null);
        }

        public Task<IEnumerable<UserEmotionLog>?> GetUserEmotionLogs(string userId)
        {
            return Task.FromResult(_context.UserEmotionLogs.Where(l => l.UserId == userId).AsEnumerable() ?? null);
        }

        public Task<List<Dictionary<UserEmotionLog, string>>?> GetUserEmotionLogsByCategory(string userId, ContentCategory contentCategory)
        {
            var query = from el in _context.UserEmotionLogs.Where(q => q.UserId == userId && q.VideoCategory == contentCategory)
                        join v in _context.Videos on el.VideoId equals v.Id
                        select new
                        {
                            EmotionLog = el,
                            Propmt = ExtractPrompt(v.TextPrompts, el.PromptKey)
                        };
            return Task.FromResult(query.Select(x => new Dictionary<UserEmotionLog, string> { { x.EmotionLog, x.Propmt } }).ToList() ?? null);
        }
        public Task<IEnumerable<UserEmotionLog?>?> GetLastUserEmotionLogsPerCategory(string userId)
        {
            return Task.FromResult(_context.UserEmotionLogs.Where(i => i.UserId == userId).GroupBy(l => l.VideoCategory).Select(g => g.OrderByDescending(l => l.CreatedDateTimeUTC).FirstOrDefault()).AsEnumerable() ?? null);
        }

        public Task<UserEmotionLog?> UpdateEmotionLog(string userId, int logId, string content)
        {
            // ~ last modified by: `userId` -> not implemented
            var log = _context.UserEmotionLogs.Find(logId);
            if (log is not null)
            {
                if (!string.IsNullOrEmpty(content) && !string.IsNullOrWhiteSpace(content))
                {
                    log.Content = content;
                    log.LastModifiedDateTimeUTC = DateTime.UtcNow;
                    _context.SaveChanges();
                }
            }
            return Task.FromResult(log ?? null);
        }


        public Task<List<Dictionary<UserEmotionLog, string>>?> TestQuery(string userId, ContentCategory contentCategory)
        {
            var query = from el in _context.UserEmotionLogs.Where(q => q.UserId == userId && q.VideoCategory == contentCategory)
                        join v in _context.Videos on el.VideoId equals v.Id
                        select new
                        {
                            EmotionLog = el,
                            Propmt = ExtractPrompt(v.TextPrompts, el.PromptKey)
                        };
            return Task.FromResult(query.Select(x => new Dictionary<UserEmotionLog, string> { { x.EmotionLog, x.Propmt } }).ToList() ?? null);
        }

        public Task<Video?> CreateVideo(string creatorId, ContentCategory category, int step, string videoUrl, string? title = null, string? body = null, string? textPrompts = null, string? pdfUrl = null, string? videoName = null)
        {
            var res = _context.Videos.Add(new Video
            {
                CreatorId = creatorId,
                Category = category,
                Step = step,
                VideoUrl = videoUrl,
                Title = title,
                Body = body,
                TextPrompts = textPrompts,
                PdfUrl = pdfUrl,
                VideoName = videoName,
                CreatedDateTimeUTC = DateTime.UtcNow,
                IsActive = true,
                LastModifiedByUserId = creatorId,
                LastModifiedDateTimeUTC = DateTime.UtcNow
            });
            _context.SaveChanges();
            return Task.FromResult(res.Entity ?? null);
        }


        public Task<Video?> DeleteVideo(int videoId)
        {
            var video = _context.Videos.Find(videoId);
            if (video is not null)
            {
                var res = _context.Videos.Remove(video);
                _context.SaveChanges();
                return Task.FromResult(res.Entity ?? null);
            }
            return Task.FromResult<Video?>(null);
        }

        // ~ getter methods:  don't need persistence

        public Task<IEnumerable<Video>?> GetAllVideos()
        {
            return Task.FromResult(IncludeVideoRelations()
                .AsEnumerable() ?? null);
        }

        public Task<IEnumerable<Video>?> GetAngerVideos()
        {
            return Task.FromResult(IncludeVideoRelations().Where(v => v.Category == ContentCategory.Anger).AsEnumerable() ?? null);
        }

        public Task<IEnumerable<Video>?> GetAnxietyVideos()
        {
            return Task.FromResult(IncludeVideoRelations().Where(v => v.Category == ContentCategory.Anxiety).AsEnumerable() ?? null);
        }

        public Task<IEnumerable<Video>?> GetDepressionVideos()
        {
            return Task.FromResult(IncludeVideoRelations().Where(v => v.Category == ContentCategory.Depression).AsEnumerable() ?? null);
        }

        public Task<IEnumerable<Video>?> GetGuiltVideos()
        {
            return Task.FromResult(IncludeVideoRelations().Where(v => v.Category == ContentCategory.Guilt).AsEnumerable() ?? null);
        }

        public Task<IEnumerable<Video>?> GetABCVideos()
        {
            return Task.FromResult(IncludeVideoRelations().Where(v => v.Category == ContentCategory.ABCs).AsEnumerable() ?? null);
        }


        // ~ helper methods
        private static bool ValidString(string q)
        {
            return !(string.IsNullOrEmpty(q) && string.IsNullOrWhiteSpace(q));
        }

        private static string? ExtractPrompt(string? jsonString, string key)
        {
            try
            {
                if (jsonString == null) throw new Exception("Null TextPrompts field");
                Dictionary<string, string>? prompts = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);
                if (prompts is not null)
                {
                    return prompts.ContainsKey(key) ? prompts[key] : throw new Exception("Missing Text Prompt");
                }
                throw new Exception("Bad or missing Text Prompts JSON string");
            }
            catch
            {
                return null;
            }
        }
    }
}
