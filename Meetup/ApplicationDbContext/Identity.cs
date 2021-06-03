using Meetup.ApplicationDbContext.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Meetup.ApplicationDbContext
{
    public class Identity : IdentityDbContext<ApplicationUser>
    {

        public Identity(DbContextOptions<Identity> options) : base(options)
        {
        }
    }
}
