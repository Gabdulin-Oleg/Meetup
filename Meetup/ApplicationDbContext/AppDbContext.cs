using Meetup.ApplicationDbContext.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.ApplicationDbContext
{
    public class AppDbContext : DbContext
    {
        DbSet<User> Users { get; set; }
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
