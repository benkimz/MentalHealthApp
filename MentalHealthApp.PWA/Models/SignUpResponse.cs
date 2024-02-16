namespace MentalHealthApp.PWA.Models
{
    public class SignUpResponse
    {
        public bool Success { get; set; }

        public string? Message { get; set; }

        public ApiAppUser User { get; set; } = new ApiAppUser(); 
    }
}
