using Meetup.ApplicationDbContext.Model;
using Meetup.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup
{
    public class DataSeet 
    {
        private readonly UserManager<ApplicationUser> userManager;
        AdminOption adminOption;

        public DataSeet(IOptions<AdminOption> options, UserManager<ApplicationUser> userManager)
        {
            adminOption = options.Value;
            this.userManager = userManager;
        }
        public async Task SeedData()
        {
            
            ApplicationUser applicationUser = new ApplicationUser()
            {
                UserName = adminOption.UserName,
                Email = adminOption.Email,
                EmailConfirmed = true
            };
            
                await userManager.CreateAsync(applicationUser, adminOption.Password);
                await userManager.AddToRoleAsync(applicationUser, "admin");
            

        }
    }

    public class AdminOption
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
