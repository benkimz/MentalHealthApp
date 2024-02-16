using MentalHealthApp.PWA.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json;

namespace MentalHealthApp.PWA.Data.Context.Entities
{
    public class Video
    {
        public int Id { get; set; }

        public int Step { get; set; }

        [MaxLength(255)]
        public string? Title { get; set; }

        public string? Body { get; set; }

        public string? TextPrompts { get; set; }

        [Required]
        [MaxLength(512)]
        public string? VideoUrl { get; set; }

        [MaxLength(512)]
        public string? PdfUrl { get; set; }

        [MaxLength(255)]
        public string? VideoName { get; set; }

        public ContentCategory Category { get; set; }

        public bool IsActive { get; set; }

        /* 
         * ~ just incase a users table is needed in the database
         * ~ will set a relationship between the video content & the creator
         * 
        public int CreatorId { get; set; }
        public required virtual AppUser Creator { get; set; } 
        */
        [Required]
        [MaxLength(512)]
        public required string CreatorId { get; set; }

        public DateTime CreatedDateTimeUTC { get; set; }

        public string? LastModifiedByUserId { get; set; }

        public DateTime? LastModifiedDateTimeUTC { get; set; }

        public Dictionary<string, string> Prompts()
        {
            try
            {
                return JsonSerializer.Deserialize<Dictionary<string, string>>(TextPrompts!)!;
            }
            catch
            {
                return new Dictionary<string, string>();
            }
        }
    }
}
