namespace MentalHealthApp.PWA.Models
{
    public class LoginResponse
    {
        public bool Success { get; set; } 

        public string? Message { get; set; }

        public ApiAppUser User { get; set; } = new ApiAppUser();

        public string Token { get; set; } = string.Empty;
    }
}
