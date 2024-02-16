using Microsoft.AspNetCore.Components;

namespace MentalHealthApp.PWA.Shared.ContentInterface.BaseClasses
{
    public class ContentTextBodyBase : ComponentBase
    {
        [Parameter]
        public string? TextBody { get; set; }
    }
}
