using MentalHealthApp.PWA.Models;
using MentalHealthApp.PWA.Services.Interfaces;

namespace MentalHealthApp.PWA.Services.Singleton
{
    public class TokenManager
    {
        private readonly ICookieAccess _cookieAccess;

        public TokenManager(ICookieAccess cookieAccess)
        {
            _cookieAccess = cookieAccess;
            ValidateUserToken();
        }

        public static ApiAppUser? User { get; set; }

        private async void ValidateUserToken()
        {
            if (User == null)
                User = await _cookieAccess.GetAppUser();
        }

        public static string GetTimeElapsed(DateTime dateTime)
        {
            long timestamp = new DateTimeOffset(dateTime).ToUnixTimeSeconds();
            long now = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            long secondsElapsed = now - timestamp;

            var intervals = new[]
            {
                new { Label = "year", Seconds = 31536000 },
                new { Label = "month", Seconds = 2592000 },
                new { Label = "week", Seconds = 604800 },
                new { Label = "day", Seconds = 86400 },
                new { Label = "hour", Seconds = 3600 },
                new { Label = "minute", Seconds = 60 }
            };

            foreach (var interval in intervals)
            {
                long elapsed = secondsElapsed / interval.Seconds;

                if (elapsed >= 1)
                {
                    return elapsed == 1 ? $"{elapsed} {interval.Label} ago" : $"{elapsed} {interval.Label}s ago";
                }
            }

            return "Just now";
        }

    }
}
