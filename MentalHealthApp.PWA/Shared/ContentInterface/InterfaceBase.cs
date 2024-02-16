using System.Text.Json;
using MentalHealthApp.PWA.Data.Context.Entities;
using MentalHealthApp.PWA.Data.Context.Interfaces;
using MentalHealthApp.PWA.Services.Interfaces;
using MentalHealthApp.PWA.Services.Singleton;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MentalHealthApp.PWA.Shared.ContentInterface
{
    public class InterfaceBase : ComponentBase
    {
        [Inject]
        protected IJSRuntime? JSRuntime { get; set; }

        [Inject]
        protected ICookieAccess? CookieAccess { get; set; }

        [Inject]
        protected TokenManager? TokenManager { get; set; }

        [Inject]
        protected NavigationManager? NavigationManager { get; set; }

        [Inject]
        public IVideoContentRepository? videoContentRepository { get; set; }

        protected string EngageFieldPlaceholder => new string('_', 720);

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender && JSRuntime is not null)
            {
                await JSRuntime.InvokeVoidAsync("app.theme.initializeAppTheme", "dark-menu-items");
                if (JSRuntime is not null && targetContent is not null)
                {
                    await JSRuntime.InvokeVoidAsync("app.frames.location.replace", "vid-frame", targetContent?.VideoUrl);
                    StateHasChanged();
                }
            }
        }

        [Parameter]
        public bool MustSignIn { get; set; } = true;

        // ~ code
        [Parameter]
        public IEnumerable<Video>? Videos { get; set; }

        [Parameter]
        public object? TextPrompts { get; set; }

        private int currentIndex { get; set; } = 0;

        protected Video? targetContent { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            targetContent = Videos?.FirstOrDefault() ?? null;

            // the user must be logged in
            if (CookieAccess != null && TokenManager != null && NavigationManager != null && MustSignIn == true)
            {
                if (TokenManager.User == null)
                {
                    NavigationManager.NavigateTo("login");
                }
            }
        }

        protected async void GoToPrevious()
        {
            if (Videos is not null)
            {
                currentIndex = currentIndex > 0 ? currentIndex - 1 : Videos.Count() - 1;
                targetContent = Videos.ElementAtOrDefault(currentIndex);
                if (JSRuntime is not null)
                {
                    await JSRuntime.InvokeVoidAsync("app.frames.location.replace", "vid-frame", targetContent?.VideoUrl);
                }
            }
            StateHasChanged();
        }


        protected async void GoToNext()
        {
            if (Videos is not null)
            {
                currentIndex = currentIndex >= Videos.Count() - 1 ? 0 : currentIndex + 1;
                targetContent = Videos.ElementAtOrDefault(currentIndex);
                if (JSRuntime is not null)
                {
                    await JSRuntime.InvokeVoidAsync("app.frames.location.replace", "vid-frame", targetContent?.VideoUrl);
                }
            }
            StateHasChanged();
        }

        public static bool IsValidUrl(string? url)
        {
            return (!string.IsNullOrEmpty(url) && !string.IsNullOrWhiteSpace(url));
        }

        protected string EmotionLogInput { get; set; } = string.Empty;
        protected void EnterEmotionLog(string e) { EmotionLogInput = e; }
        protected async void SaveUserLog(string promptKey)
        {
            if (videoContentRepository != null && TokenManager != null)
            {
                if (TokenManager.User != null && targetContent != null)
                {
                    var userId = TokenManager.User.Id;
                    await videoContentRepository.AddEmotionLog(userId: userId.ToString(), videoId: targetContent.Id, contentCategory: targetContent.Category, promptKey: promptKey, content: EmotionLogInput);
                }
            }
            EmotionLogInput = string.Empty; StateHasChanged();
        }
    }
}
