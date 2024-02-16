using MentalHealthApp.PWA.Data.Context.Enums;
using System.ComponentModel.DataAnnotations;

namespace MentalHealthApp.PWA.Data.Context.Entities
{
    public class AppUser
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(512)]
        public required string UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string? LastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Surname { get; set; }

        [Required]
        [MaxLength(255)]
        public required string UserName { get; set; }

        public UserRole Role { get; set; }
    }
}
