using Meetup.ApplicationDbContext;
using Meetup.ApplicationDbContext.Model;
using Meetup.Services.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Meetup
{
    public class DataSeet
    {
        private readonly AppDbContext dbContext;
        private readonly Identity identityDbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        AdminOption adminOption;

        public DataSeet(IOptions<AdminOption> options, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext dbContext, Identity identityDbContext)
        {
            adminOption = options.Value;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.dbContext = dbContext;
            this.identityDbContext = identityDbContext;
        }
        public async Task SeedData()
        {
            await dbContext.Database.MigrateAsync();
            await identityDbContext.Database.MigrateAsync();

            ApplicationUser applicationUser = new ApplicationUser()
            {
                UserName = adminOption.UserName,
                Email = adminOption.Email,
                EmailConfirmed = true
            };
            await roleManager.CreateAsync(new IdentityRole(adminOption.Role));
            await userManager.CreateAsync(applicationUser, adminOption.Password);
            await userManager.AddToRoleAsync(applicationUser, adminOption.Role);
            if (await dbContext.Meetups.FirstOrDefaultAsync(p => p.Id == "1") == null)
            {
                await dbContext.Set<Meetups>().AddAsync(new Meetups { Id = "1" });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
