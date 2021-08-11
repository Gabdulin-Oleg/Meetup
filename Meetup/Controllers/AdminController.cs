using AutoMapper;
using Meetup.ApplicationDbContext.Model;
using Meetup.Interfaces;
using Meetup.Interfaces.Dtos;
using Meetup.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Meetup.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        readonly IAdminService adminService;
        readonly IMapper mapper;
        readonly SignInManager<ApplicationUser> signInManager;

        public AdminController(IAdminService adminService, IMapper mapper, SignInManager<ApplicationUser> signInManager = null)
        {
            this.adminService = adminService;
            this.mapper = mapper;
            this.signInManager = signInManager;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
                return Ok();
            return BadRequest("Неверный логин или пароль");
        }

        [Authorize(Roles = "admin")]
        [HttpPost("CreateMeetupLocation")]
        public async Task<IActionResult> CreateMeetupLocation(MeetupLocationViewModel meetupLocationViewModel)
        {
            var meetupLocationDto = mapper.Map<MeetupLocationDto>(meetupLocationViewModel);
            await adminService.CreateMeetupLocation(meetupLocationDto);
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpGet("GetAllMeetup")]
        public async Task<IActionResult> GetAllMeetupAsync()
        {
            var result = await adminService.GetAllMeetupsAsync();
            return Ok(result);
        }
        [Authorize(Roles = "admin")]
        [HttpGet("GetMeetupById/{id}")]
        public async Task<IActionResult> GetMeetupById(string id)
        {
            var result = await adminService.GetMeetupById(id);

            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUserAsync()
        {
            var result = await adminService.GetAllUsersAsync();
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("User/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(string id)
        {
            var result = await adminService.GetUserByIdAsync(id);
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("usersInMeetup{id}")]
        public async Task<IActionResult> GetUsersInMeetupAsync(string id)
        {
            var result = await adminService.GetUsersInMeetupAsync(id);
            return Ok(result);
        }
        [Authorize(Roles = "admin")]
        [HttpGet("GetAllMeetuplocation")]
        public async Task<IActionResult> GetAllMeetuplocation()
        {
            var result = await adminService.GetAllMeetupLocationAsync();
            return Ok(result);
        }
        [Authorize(Roles = "admin")]
        [HttpGet("GetMeetupLocationById/{id}")]
        public async Task<IActionResult> GetMeetuplocationById(string id)
        {
            var result = await adminService.GetMeetupLocationByIdAsync(id);

            return Ok(result);
        }
    }
}
