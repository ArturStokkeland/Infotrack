using InfoTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoTrack.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<ScrapeResult> ScrapeResults { get; set; }
    }
}
