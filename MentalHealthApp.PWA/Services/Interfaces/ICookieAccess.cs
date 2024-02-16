using MentalHealthApp.PWA.Models;

namespace MentalHealthApp.PWA.Services.Interfaces
{
    public interface ICookieAccess
    {
        Task<string?> GetUserToken();

        Task<ApiAppUser?> GetAppUser(string? token = null);
    }
}
