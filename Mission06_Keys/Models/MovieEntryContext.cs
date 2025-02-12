using Microsoft.EntityFrameworkCore;

namespace Mission06_Keys.Models
{
    public class MovieEntryContext : DbContext
    {
        public MovieEntryContext(DbContextOptions<MovieEntryContext> options)
            : base(options) { }

        public DbSet<MovieEntry> MovieEntries { get; set; }
    }
}
