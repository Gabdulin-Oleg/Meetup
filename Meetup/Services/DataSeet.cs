using Meetup.ApplicationDbContext.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Meetup
{
    public class DataSeet
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        AdminOption adminOption;

        public DataSeet(IOptions<AdminOption> options, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            adminOption = options.Value;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task SeedData()
        {

            ApplicationUser applicationUser = new ApplicationUser()
            {
                UserName = adminOption.UserName,
                Email = adminOption.Email,
                EmailConfirmed = true
            };
            await roleManager.CreateAsync(new IdentityRole(adminOption.Role));
            await userManager.CreateAsync(applicationUser, adminOption.Password);
            await userManager.AddToRoleAsync(applicationUser, adminOption.Role);


        }
    }

    public class AdminOption
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
