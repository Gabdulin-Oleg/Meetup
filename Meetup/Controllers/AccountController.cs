//using MailKit;
using Meetup.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetup.ApplicationDbContext.Model;

namespace Meetup.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        IEmailSender emailService;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.emailService = emailService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { Email = model.Email, UserName = model.Email };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // генерация токена для пользователя
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { userId = user.Id, code = code },
                        protocol: HttpContext.Request.Scheme);
                    //IMailService emailService;// = new EmailService();
                    await emailService.SendEmailAsync(model.Email, "Confirm your account",
                        $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");

                    return Content("Для завершения регистрации проверьте электронную почту и перейдите по ссылке, указанной в письме");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return Ok();
        }
    }
}
