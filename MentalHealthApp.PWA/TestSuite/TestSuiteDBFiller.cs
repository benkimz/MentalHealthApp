using System.Text.Json;
using MentalHealthApp.PWA.Data.Context;
using MentalHealthApp.PWA.Data.Context.Entities;
using MentalHealthApp.PWA.Data.Enums;

namespace MentalHealthApp.PWA;

public class TestSuiteDBFiller : ITestSuiteDBFiller
{
    private readonly AppDbContext _context;

    public TestSuiteDBFiller(AppDbContext context)
    {
        _context = context;
    }

    public async Task LoadDB()
    {
        List<DBObject> db = ReadJsonFile("TestSuite/mhapp.db.json");
        foreach (var entry in db)
        {
            Video video = new Video
            {
                Step = entry.Step,
                Title = entry.Title,
                Body = entry.Body,
                TextPrompts = entry.JsonPrompts(),
                VideoUrl = entry.VideoUrl,
                PdfUrl = entry.PdfUrl,
                VideoName = entry.VideoName,
                Category = (ContentCategory)entry.Category,
                IsActive = true,
                CreatorId = entry.CreatorId,
                CreatedDateTimeUTC = entry.CreatedDateTimeUTC,
                LastModifiedByUserId = entry.LastModifiedByUserId,
                LastModifiedDateTimeUTC = entry.LastModifiedDateTimeUTC
            };
            await _context.Videos.AddAsync(video);
            await _context.SaveChangesAsync();

            Console.WriteLine($"Title: {video.Title}");
        }
        await Task.FromResult<int>(0);
    }

    public List<DBObject> ReadJsonFile(string path)
    {
        string json = File.ReadAllText(path);
        List<DBObject> dbObjects = JsonSerializer.Deserialize<List<DBObject>>(json)!;
        return dbObjects;
    }

    public class DBObject
    {
        public int Id { get; set; }
        public int Step { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public string? TextPrompt { get; set; }
        public string? VideoUrl { get; set; }
        public string? PdfUrl { get; set; }
        public string? VideoName { get; set; }
        public int Category { get; set; }
        public string? IsActive { get; set; }
        public required string CreatorId { get; set; }
        public DateTime CreatedDateTimeUTC { get; set; }
        public string? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedDateTimeUTC { get; set; }
        public string? TextPrompt2 { get; set; }
        public string? TextPrompt3 { get; set; }
        public string? TextPrompt4 { get; set; }

        public string JsonPrompts()
        {
            var propertiesToSerialize = new Dictionary<string, string>();
            var prompt = GetType().GetProperty("TextPrompt")?.GetValue(this, null) as string;
            if (prompt is not null)
            {
                if (!string.IsNullOrEmpty(prompt) && !string.IsNullOrWhiteSpace(prompt))
                {
                    propertiesToSerialize.Add("1", prompt);
                }

                for (int i = 2; i <= 4; i++)
                {
                    var propertyValue = GetType().GetProperty($"TextPrompt{i}")?.GetValue(this, null) as string;
                    if (propertyValue != null)
                    {
                        propertyValue = propertyValue.Trim();
                        if (!string.IsNullOrEmpty(propertyValue) && !string.IsNullOrWhiteSpace(propertyValue))
                        {
                            propertiesToSerialize.Add(i.ToString(), propertyValue);
                        }
                    }
                }
            }
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            return JsonSerializer.Serialize(propertiesToSerialize, serializeOptions);
        }
    }

}
