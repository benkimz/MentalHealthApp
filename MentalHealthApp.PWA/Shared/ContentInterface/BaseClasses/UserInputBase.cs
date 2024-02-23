using MentalHealthApp.PWA.Data.Context.Interfaces;
using MentalHealthApp.PWA.Services.Singleton;
using Microsoft.AspNetCore.Components;

namespace MentalHealthApp.PWA.Shared.ContentInterface.BaseClasses
{
    public class UserInputBase : ComponentBase
    {
        [Parameter]
        public string? ValueString { get; set; }
        [Parameter]
        public string Placeholder { get; set; } = "Type something...";
        [Parameter]
        public int? VideoId { get; set; }
        [Parameter]
        public string? PromptKey { get; set; }

        [Parameter]
        public Action<string>? OnSave { get; set; }
        [Parameter]
        public Action<string?>? OnInput { get; set; }

        protected void SaveEmotionLog()
        {
            if (OnSave is not null)
            {
                OnSave.Invoke(PromptKey ?? string.Empty);
            }
        }

        protected void InputEmotionLog(ChangeEventArgs args)
        {
            ValueString = args.Value?.ToString() ?? string.Empty;
            if (OnInput is not null)
            {
                OnInput.Invoke(ValueString);
            }
        }

    }
}
