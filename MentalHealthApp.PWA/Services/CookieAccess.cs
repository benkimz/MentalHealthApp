using MentalHealthApp.PWA.Models;
using MentalHealthApp.PWA.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MentalHealthApp.PWA.Services
{
    public class CookieAccess : ICookieAccess
    {
        private IApiService _apiService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieAccess(IApiService apiService, IHttpContextAccessor httpContextAccessor)
        {
            _apiService = apiService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiAppUser?> GetAppUser(string? token = null)
        {
            token = token == null ? await GetUserToken() : token;
            return token != null ? await _apiService.GetAppUser(token) : null;
        }
        
        public Task<string?> GetUserToken()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context is not null)
            {
                try
                {
                    return Task.FromResult(context.Request.Cookies.ContainsKey("token") ? context.Request.Cookies["token"] : null);
                }
                catch { }
            }
            return Task.FromResult<string?>(null);
        }
    }
}
