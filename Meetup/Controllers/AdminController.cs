using AutoMapper;
using Meetup.Interfaces;
using Meetup.Interfaces.Dtos;
using Meetup.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Meetup.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class AdminController : ControllerBase
    {
        readonly IAdminService adminService;
        readonly IMapper mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            this.adminService = adminService;
            this.mapper = mapper;
        }

        [HttpPost("CreateMeetupLocation")]
        public async Task<IActionResult> CreateMeetupLocation(MeetupLocationViewModel meetupLocationViewModel)
        {
            var meetupLocationDto = mapper.Map<MeetupLocationDto>(meetupLocationViewModel);
            await adminService.CreateMeetupLocation(meetupLocationDto);
            return Ok();
        }

        [HttpGet("GetAllMeetup")]
        public async Task<IActionResult> GetAllMeetupAsync()
        {
            var result = await adminService.GetAllMeetupsAsync();
            return Ok(result);
        }
        [HttpGet("GetMeetupById/{id}")]
        public async Task<IActionResult> GetMeetupById(string id)
        {
            var result = await adminService.GetMeetupById(id);

            return Ok(result);
        }

        [HttpGet("Users")]
        public async Task<IActionResult> GetAllUserAsync()
        {
            var result = await adminService.GetAllUsersAsync();
            return Ok(result);
        }

        [HttpGet("User/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(string id)
        {
            var result = await adminService.GetUserByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("usersInMeetup{id}")]
        public async Task<IActionResult> GetUsersInMeetupAsync(string id)
        {
            var result = await adminService.GetUsersInMeetupAsync(id);
            return Ok(result);
        }
        [HttpGet("GetAllMeetuplocation")]
        public async Task<IActionResult> GetAllMeetuplocation()
        {
            var result = await adminService.GetAllMeetupLocationAsync();
            return Ok(result);
        }
        [HttpGet("GetMeetupLocationById/{id}")]
        public async Task<IActionResult> GetMeetuplocationById(string id)
        {
            var result = await adminService.GetMeetupLocationByIdAsync(id);

            return Ok(result);
        }
    }
}
