using AutoMapper;
using Meetup.ApplicationDbContext;
using Meetup.ApplicationDbContext.Model;
using Meetup.Services.Interfaces;
using Meetup.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Meetup.Services
{
    public class UserService : ControllerBase, IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        readonly AppDbContext dbContext;
        IMapper mapper;


        public UserService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, AppDbContext dbContext)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, RegistredViewModel>();
                cfg.CreateMap<RegistredViewModel, User>();
            });
            this.mapper = new Mapper(config);
            this.dbContext = dbContext;
        }

        public async Task<bool> RegistrationUserAsync(RegistredViewModel model)
        {
            var user = mapper.Map<User>(model);
            ApplicationUser applicationUser = new ApplicationUser { Email = user.Email, UserName = user.Email };
            var result = await userManager.CreateAsync(applicationUser, user.Password);

            if (result.Succeeded)
            {
                dbContext.Set<User>().Add(user);
                dbContext.SaveChanges();
                // установка куки
                await signInManager.SignInAsync(applicationUser, false);
                return true;
            }
            return false;
        }

        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (await userManager.IsInRoleAsync((user), "admin"))
            {
                await signInManager.SignInAsync(user, false);
                return RedirectToAction("Get", "Admin");
            }
            else
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Get", "User");
                }
                else
                {
                    return Unauthorized();
                }
            }
        }
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await signInManager.SignOutAsync();
            return RedirectToAction("Get", "User");
        }
    }
}
