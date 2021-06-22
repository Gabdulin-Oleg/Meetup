using Meetup.ApplicationDbContext.Model;
using Microsoft.EntityFrameworkCore;

namespace Meetup.ApplicationDbContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Meetups> Meetups { get; set; }
        public DbSet<MeetupLocation> MeetupLocations { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
               .HasIndex(u => u.Email)
               .IsUnique();

        }
    }
}
