using Meetup.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "admin")]
    public class AdminController : ControllerBase
    {
        IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpGet("users")]
        public IActionResult GetAllUser()
        {
            var result = adminService.GetAllUsers();
            return Ok(result);
        }
        [HttpGet("user/{id}")]
        public IActionResult GetUserById(int id)
        {
            var result = adminService.GetUserById(id);
            return Ok(result);
        }
    }
}
