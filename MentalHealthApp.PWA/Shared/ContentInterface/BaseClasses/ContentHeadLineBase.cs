using Microsoft.AspNetCore.Components;

namespace MentalHealthApp.PWA.Shared.ContentInterface.BaseClasses
{
    public class ContentHeadLineBase : ComponentBase
    {
        [Parameter]
        public int ContentStep { get; set; }

        [Parameter]
        public string? ContentTitle { get; set; } 
    }
}
