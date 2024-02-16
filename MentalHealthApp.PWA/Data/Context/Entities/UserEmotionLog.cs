using System.ComponentModel.DataAnnotations;
using MentalHealthApp.PWA.Data.Enums;

namespace MentalHealthApp.PWA.Data.Context.Entities
{
    public class UserEmotionLog
    {
        public int Id { get; set; }

        public int VideoId { get; set; }

        public ContentCategory VideoCategory { get; set; }

        [Required]
        [MaxLength(128)]
        public required string PromptKey { get; set; }

        [Required]
        [MaxLength(1024)]
        public required string Content { get; set; }

        [Required]
        [MaxLength(256)]
        public required string UserId { get; set; }

        public DateTime CreatedDateTimeUTC { get; set; }

        public DateTime? LastModifiedDateTimeUTC { get; set; }
    }
}
