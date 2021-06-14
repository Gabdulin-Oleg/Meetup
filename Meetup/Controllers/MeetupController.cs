using AutoMapper;
using Meetup.ApplicationDbContext;
using Meetup.ApplicationDbContext.Model;
using Meetup.Services.Interfaces;
using Meetup.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Meetup.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeetupController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        IEmailSender emailService;
        readonly AppDbContext dbContext;
        IMapper mapper;


        public MeetupController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, AppDbContext dbContext, IEmailSender emailService)
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
            this.emailService = emailService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegistredViewModel model)
        {
            var user = mapper.Map<User>(model);
            ApplicationUser applicationUser = new ApplicationUser { Email = user.Email, UserName = user.Email };
            var result = await userManager.CreateAsync(applicationUser, user.Password);
            if (result.Succeeded)
            {
                var code = await userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
                var callbackUrl = Url.Action("ConfirmEmail","Meetup",
                  new { userId = applicationUser.Id, code = code }, HttpContext.Request.Scheme,host: HttpContext.Request.Host.Value);

                await emailService.SendEmailAsync(model.Email, "Confirm your account",
                    $"Подтвердите регистрацию, перейдя по <a href='{callbackUrl}'>ссылке</a>");

                await dbContext.Set<User>().AddAsync(user);
                await dbContext.SaveChangesAsync();
                // установка куки
                await signInManager.SignInAsync(applicationUser, false);
                return RedirectToAction("Get", "Meetup");
            }
            await userManager.DeleteAsync(applicationUser);
            return BadRequest("Пользователь с таким Email уже сушествует");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                // проверяем, подтвержден ли email
                if (!await userManager.IsEmailConfirmedAsync(user))
                {
                    return BadRequest("Вы не подтвердили свой email");
                }

            }

            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                if (await userManager.IsInRoleAsync(user,"admin"))
                {
                    // перенаправляем на админку если это админ
                    return RedirectToAction("GetAllUser", "Admin");
                }
                return RedirectToAction("Get", "Meetup");
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await signInManager.SignOutAsync();
            return RedirectToAction("Get", "Meetup");
        }

        [HttpGet("ConfirmEmail")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest();
            }
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest();
            }
            var result = await userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                user.EmailConfirmed = true;
                await userManager.UpdateAsync(user);
                return RedirectToAction("Get", "Meetup");
            }
            else
                return BadRequest();
        }
    }
}
