using MentalHealthApp.PWA.Data.Context.Entities;
using MentalHealthApp.PWA.Data.Context.Interfaces;
using MentalHealthApp.PWA.Services;
using MentalHealthApp.PWA.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MentalHealthApp.PWA.Pages.AngerPage
{
    public class AngerBase : ComponentBase
    {
        [Inject]
        private IJSRuntime? JSRuntime { get; set; }

        protected string Tag => "Anger";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                if (JSRuntime is not null)
                {
                    await JSRuntime.InvokeVoidAsync("contentInterface.setTitle", Tag.ToUpper());
                }
            }
        }

        // ~ code
        [Inject]
        private IVideoContentRepository? videoContentRepository { get; set; }

        protected IEnumerable<Video>? videos { get; set; }

        [Inject]
        protected ICookieAccess? CookieAccess { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if (videoContentRepository is not null)
            {
                videos = await videoContentRepository.GetAngerVideos();
                StateHasChanged();
            }
        }
    }
}
