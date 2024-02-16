using MentalHealthApp.PWA.Data.Context.Entities;
using MentalHealthApp.PWA.Data.Context.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MentalHealthApp.PWA.Pages.DepressionPage
{
    public class DepressionBase : ComponentBase
    {
        [Inject]
        private IJSRuntime? JSRuntime { get; set; }

        protected string Tag => "Depression";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
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

        protected override async Task OnInitializedAsync()
        {
            if (videoContentRepository is not null)
            {
                videos = await videoContentRepository.GetDepressionVideos();
                StateHasChanged();
            }
        }
    }
}
