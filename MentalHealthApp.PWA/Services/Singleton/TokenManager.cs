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
    }
}
