using Meetup.ApplicationDbContext.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.ApplicationDbContext
{
    public class Identity : IdentityDbContext<ApplicationUser>
    {
       
        public Identity(DbContextOptions<Identity> options) : base(options)
        {
        }
    }
}
