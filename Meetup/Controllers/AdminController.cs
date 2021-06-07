using Meetup.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Meetup.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class AdminController : ControllerBase
    {
        IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet("admin/Users")]
        public IActionResult GetAllUser()
        {
            var result = adminService.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("admin/User/{id}")]
        public IActionResult GetUserById(int id)
        {
            var result = adminService.GetUserById(id);
            return Ok(result);
        }
    }
}
