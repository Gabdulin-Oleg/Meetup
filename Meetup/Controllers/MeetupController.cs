using Meetup.Services.Interfaces;
using Meetup.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Meetup.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeetupController : ControllerBase
    {
        IAdminService adminService;
        IUserService userService;

        public MeetupController(IUserService userService, IAdminService adminService)
        {
            this.userService = userService;
            this.adminService = adminService;
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

            if (result)
            {
                return RedirectToAction("Get", "Meetup");
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
            return await userService.Logout();
        }

        [Authorize(Roles = "admin")]
        [HttpGet("admin/Users")]
        public IActionResult GetAllUser()
        {
            var result = adminService.GetAllUsers();
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("admin/User/{id}")]
        public IActionResult GetUserById(int id)
        {
            var result = adminService.GetUserById(id);
            return Ok(result);
        }
    }
}
