using Meetup.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Meetup.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> RegistrationUserAsync(RegistredViewModel model);
        public Task<IActionResult> LoginAsync(LoginViewModel model);
    }
}