using Microsoft.AspNetCore.Components;

namespace MentalHealthApp.PWA.Shared.ContentInterface.BaseClasses
{
    public class VideoIframeBase : ComponentBase
    {
        [Parameter]
        public string? VideoUrl { get; set; }

        [Parameter]
        public string? VideoName { get; set;}

        [Parameter]
        public int ContentStep { get; set; }
    }
}
