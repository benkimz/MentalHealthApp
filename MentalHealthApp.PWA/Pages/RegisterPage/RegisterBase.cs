using MentalHealthApp.PWA.Models;
using MentalHealthApp.PWA.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MentalHealthApp.PWA.Pages.RegisterPage
{
    public class RegisterBase : ComponentBase
    {
        [Inject]
        private IApiService? _api { get; set; } 

        [Inject]
        private NavigationManager? _navManager { get; set; }

        [Inject]
        private IJSRuntime? JSRuntime { get; set; }

        protected string? FirstName { get; set; } 

        protected string? LastName { get; set;}

        protected string? Email { get; set; } 

        protected string? PhoneNumber { get; set; } 

        protected string? Password { get; set; } 

        protected string? ConfirmPassword { get; set; }

        protected string? ErrorMessage { get; set; } 

        protected async void RegisterUser()
        {
            if(Password == ConfirmPassword && _api is not null && _navManager is not null)
            {
                if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(PhoneNumber) && !string.IsNullOrEmpty(Password))
                {
                    // set constraints on password and fields: e.t.c
                    SignUpResponse? Log = await _api.SignUpUser(userName: Email, firstName: FirstName, lastName: LastName, phoneNumber: PhoneNumber, email: Email, password: Password); 
                    if(Log is not null)
                    {
                        if(Log.Success == true)
                        {
                            ErrorMessage = null;
                            _navManager.NavigateTo("login");
                        }
                        else
                        {
                            ErrorMessage = Log.Message;
                        }
                    }
                }
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && JSRuntime is not null)
            {
                await JSRuntime.InvokeVoidAsync("authPages.setTitle", "Register");
                await JSRuntime.InvokeVoidAsync("app.theme.initializeAppTheme", "dark-root");
            }
        }
    }
}
