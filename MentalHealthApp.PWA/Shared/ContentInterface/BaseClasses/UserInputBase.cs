using Microsoft.AspNetCore.Components;

namespace MentalHealthApp.PWA.Shared.ContentInterface.BaseClasses
{
    public class UserInputBase : ComponentBase
    {
        [Parameter]
        public string Placeholder { get; set; } = "Type something...";

        [Parameter]
        public string? PromptKey { get; set; }

        [Parameter]
        public Action<string>? OnSave { get; set; }
        [Parameter]
        public Action<string?>? OnInput { get; set; }
        protected string EmotionLog { get; set; } = string.Empty;

        protected void SaveEmotionLog()
        {
            if (OnSave is not null)
            {
                OnSave.Invoke(PromptKey ?? string.Empty);
            }
            EmotionLog = string.Empty; StateHasChanged();
        }

        protected void InputEmotionLog(ChangeEventArgs args)
        {
            EmotionLog = args.Value?.ToString() ?? string.Empty;
            if (OnInput is not null)
            {
                OnInput.Invoke(EmotionLog);
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            EmotionLog = string.Empty;
        }
    }
}
