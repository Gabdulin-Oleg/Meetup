//using MailKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetup.ApplicationDbContext.Model;
using Meetup.Services.Interfaces;
using Meetup.ViewModels;

namespace Meetup.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegistredViewModel model)
        {
            bool result = await userService.RegistrationUserAsync(model);
            
            if(result)
            {
                return RedirectToAction("Get", "User");
            }
            return Unauthorized();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            return await userService.LoginAsync(model);
        }
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            return  await userService.Logout();
        }
    }
}
