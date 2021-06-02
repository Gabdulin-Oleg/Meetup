using Meetup.ApplicationDbContext.Model;
using Meetup.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.ApplicationDbContext
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
