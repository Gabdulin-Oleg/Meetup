using AutoMapper;
using Meetup.ApplicationDbContext.Model;
using Meetup.Interfaces;
using Meetup.Interfaces.Dtos;
using Meetup.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Meetup.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        readonly UserManager<ApplicationUser> userManager;
        readonly SignInManager<ApplicationUser> signInManager;
        readonly IUserService userService;
        readonly IMapper mapper;

        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IUserService userService, IMapper mapper)
        {

            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegistredViewModel model)
        {
            var userDto = mapper.Map<UserDto>(model);

            if (await userService.RegistrationAsync(userDto))
                return RedirectToAction("Get", "User");

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
                    return BadRequest("Вы не подтвердили свой email");
            }
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                if (await userManager.IsInRoleAsync(user, "admin"))

                    // перенаправляем на админку если это админ
                    return RedirectToAction("GetAllUser", "Admin");

                return RedirectToAction("Get", "User");
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
            return RedirectToAction("Get", "User");
        }

        [HttpPost("SignUpMeetup")]
        [Authorize]
        public async Task<IActionResult> SignUpMeetup(string meetupId)
        {
            await userService.SignUpMeetup(meetupId);
            return NoContent();
        }

        [HttpPost("CreateMeetup")]
        [Authorize]
        public async Task<IActionResult> CreateMeetup([FromForm] MeetupViewModel meetupViewModel)
        {
            var meetupDto = mapper.Map<MeetupDto>(meetupViewModel);

            await userService.CreateMeetup(meetupDto);
            return NoContent();
        }

        [HttpGet("ConfirmEmail")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmationEmail(string userId, string code)
        {
            if (!await userService.ConfirmationEmail(userId, code))
                return RedirectToAction("Get", "User");
            return BadRequest();
        }

        [HttpGet("GetMeetupLocationById")]
        [Authorize]
        public async Task<IActionResult> GetMeetupLocationById(string id)
        {
            var result = await userService.GetMeetupLocationByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetAllMeetupLocation")]
        [Authorize]
        public async Task<IActionResult> GetAllMeetupLocation()
        {
            var result = await userService.GetAllMeetupLocationAsync();
            return Ok(result);
        }
    }
}
