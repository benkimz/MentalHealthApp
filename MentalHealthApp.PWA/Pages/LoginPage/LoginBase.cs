using MentalHealthApp.PWA.Models;
using MentalHealthApp.PWA.Services.Interfaces;
using MentalHealthApp.PWA.Services.Singleton;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net;

namespace MentalHealthApp.PWA.Pages.LoginPage
{
    public class LoginBase : ComponentBase
    {
        [Inject]
        private IApiService? _api { get; set; }

        [Inject]
        private ICookieAccess? _cookie { get; set; }

        [Inject]
        private NavigationManager? _navManager { get; set; }

        [Inject]
        private IJSRuntime? JSRuntime { get; set; }

        [Inject]
        public TokenManager? TokenManager { get; set; }

        protected string? Email { get; set; }

        protected string? Password { get; set; } 

        protected string? ErrorMessage { get; set; }

        protected async void AuthenticateUser()
        {
            if(_api is not null && _cookie is not null && _navManager is not null)
            {
                if(Email is not null && Password is not null)
                {
                    LoginResponse? Log = await _api.SignInUser(email: Email, password: Password);
                    if(Log is not null)
                    {
                        if(Log.Success == true)
                        {
                            ErrorMessage = null;
                            if(JSRuntime is not null)
                            {
                                await JSRuntime.InvokeVoidAsync("BrowserData.SaveCookie", "token", Log.Token, 14);
                                TokenManager.User = await _cookie.GetAppUser(Log.Token);
                                await JSRuntime.InvokeVoidAsync("location.assign", "/");
                            }
                        }
                        else
                        {
                            ErrorMessage = Log.Message;
                            StateHasChanged();
                        }
                    }
                }
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && JSRuntime is not null)
            {
                await JSRuntime.InvokeVoidAsync("authPages.setTitle", "Login");
                await JSRuntime.InvokeVoidAsync("app.theme.initializeAppTheme", "dark-root");
            }
        }
    }
}
