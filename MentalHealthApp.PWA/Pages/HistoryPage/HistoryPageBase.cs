using MentalHealthApp.PWA.Data.Context.Entities;
using MentalHealthApp.PWA.Data.Context.Interfaces;
using MentalHealthApp.PWA.Data.Enums;
using MentalHealthApp.PWA.Services.Interfaces;
using MentalHealthApp.PWA.Services.Singleton;
using Microsoft.AspNetCore.Components;

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

    [Parameter]
    public string? category { get; set; }
    protected List<Dictionary<UserEmotionLog, string>>? EmotionLogHistory { get; set; }

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
    // protected override async Task OnAfterRenderAsync(bool firstRender)
    // {
    //     // if (videoContentRepository != null && TokenManager != null && category != null)
    //     // {
    //     //     if (TokenManager.User != null)
    //     //     {
    //     //         switch (category.Trim())
    //     //         {
    //     //             case "anger":
    //     //                 EmotionLogHistory = (await videoContentRepository.GetUserEmotionLogsByCategory(userId: TokenManager.User.Id.ToString(), contentCategory: ContentCategory.Anger))?.ToList();
    //     //                 break;
    //     //             case "anxiety":
    //     //                 EmotionLogHistory = (await videoContentRepository.GetUserEmotionLogsByCategory(userId: TokenManager.User.Id.ToString(), contentCategory: ContentCategory.Anxiety))?.ToList();
    //     //                 break;
    //     //             case "guilt":
    //     //                 EmotionLogHistory = (await videoContentRepository.GetUserEmotionLogsByCategory(userId: TokenManager.User.Id.ToString(), contentCategory: ContentCategory.Guilt))?.ToList();
    //     //                 break;
    //     //             case "depression":
    //     //                 EmotionLogHistory = (await videoContentRepository.GetUserEmotionLogsByCategory(userId: TokenManager.User.Id.ToString(), contentCategory: ContentCategory.Depression))?.ToList();
    //     //                 break;
    //     //             default: break;
    //     //         }
    //     //     }
    //     //     StateHasChanged();
    //     // }
    // }
    protected override async Task OnParametersSetAsync()
    {
        if (videoContentRepository != null && TokenManager != null && category != null)
        {
            if (TokenManager.User != null)
            {
                switch (category.Trim())
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
                    default: break;
                }
            }
            StateHasChanged();
        }
    }
}
