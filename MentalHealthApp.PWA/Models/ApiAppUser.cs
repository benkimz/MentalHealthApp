namespace MentalHealthApp.PWA.Models
{
    public class ApiAppUser
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string First_name { get; set; } = string.Empty;

        public string Last_name { get; set; } = string.Empty;

        public string Phone_number { get; set; } = string.Empty;

        public List<string> Roles { get; set; } = new List<string>();
    }
}
