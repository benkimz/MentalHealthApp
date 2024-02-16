using MentalHealthApp.PWA.Data.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace MentalHealthApp.PWA.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Video> Videos { get; set; }

        public DbSet<UserEmotionLog> UserEmotionLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("testdb");

            modelBuilder.Entity<Video>()
                .Property(p => p.CreatedDateTimeUTC)
                .HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<UserEmotionLog>()
                .Property(p => p.CreatedDateTimeUTC)
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}
