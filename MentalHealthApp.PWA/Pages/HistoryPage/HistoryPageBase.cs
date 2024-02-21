using MentalHealthApp.PWA.Data.Context.Entities;
using MentalHealthApp.PWA.Data.Context.Interfaces;
using MentalHealthApp.PWA.Data.Enums;
using MentalHealthApp.PWA.Services.Interfaces;
using MentalHealthApp.PWA.Services.Singleton;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MentalHealthApp.PWA;

public class HistoryPageBase : ComponentBase
{
    [Inject]
    private IVideoContentRepository? videoContentRepository { get; set; }
    [Inject]
    private TokenManager? TokenManager { get; set; }
    [Inject]
    private ICookieAccess? CookieAccess { get; set; }
    [Inject]
    private NavigationManager? NavigationManager { get; set; }
    [Inject]
    private IJSRuntime? JSRuntime { get; set; }

    [Parameter]
    public string? category { get; set; }
    protected List<Dictionary<string, UserEmotionLog>>? EmotionLogHistory { get; set; }

    protected override void OnInitialized()
    {
        // the user must be logged in
        if (CookieAccess != null && TokenManager != null && NavigationManager != null)
        {
            if (TokenManager.User == null)
            {
                NavigationManager.NavigateTo("login");
            }
        }
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        if (videoContentRepository is not null && TokenManager is not null && TokenManager.User is not null)
        {
            if (TokenManager.User != null)
            {
                switch (category?.Trim())
                {
                    case "anger":
                        EmotionLogHistory = (await videoContentRepository.GetUserEmotionLogsByCategory(userId: TokenManager.User.Id.ToString(), contentCategory: ContentCategory.Anger))?.ToList();
                        break;
                    case "anxiety":
                        EmotionLogHistory = (await videoContentRepository.GetUserEmotionLogsByCategory(userId: TokenManager.User.Id.ToString(), contentCategory: ContentCategory.Anxiety))?.ToList();
                        break;
                    case "guilt":
                        EmotionLogHistory = (await videoContentRepository.GetUserEmotionLogsByCategory(userId: TokenManager.User.Id.ToString(), contentCategory: ContentCategory.Guilt))?.ToList();
                        break;
                    case "depression":
                        EmotionLogHistory = (await videoContentRepository.GetUserEmotionLogsByCategory(userId: TokenManager.User.Id.ToString(), contentCategory: ContentCategory.Depression))?.ToList();
                        break;
                    default: EmotionLogHistory = (await videoContentRepository.GetDefaultHistory(userId: TokenManager.User.Id.ToString()))?.ToList(); break;
                }
            }
        }
        StateHasChanged();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        StateHasChanged();
    }

}
