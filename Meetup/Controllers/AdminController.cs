using Meetup.Interfaces;
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

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersInMeetupAsync(string id)
        {
            var result = await adminService.GetUsersInMeetupAsync(id);
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
    }
}
