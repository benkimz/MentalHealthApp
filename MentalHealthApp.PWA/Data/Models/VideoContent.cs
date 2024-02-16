using MentalHealthApp.PWA.Data.Context.Entities;
using MentalHealthApp.PWA.Data.Enums;

namespace MentalHealthApp.PWA.Data.Models
{
    public class VideoContent
    {
        public int Step { get; set; } 

        public string? Title { get; set;} 

        public string? Body { get; set; } 

        public string? TextPrompt { get; set; } 

        public string? VideoUrl { get; set; } 

        public string? PdfUrl { get; set; } 

        public string? VideoName { get; set; } 

        public ContentCategory Category { get; set; }
    }
}
