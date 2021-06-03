using Meetup.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Meetup.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<bool> RegistrationUserAsync(RegistredViewModel model);
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<IActionResult> LoginAsync(LoginViewModel model);
        /// <summary>
        /// Очистка куки
        /// </summary>
        /// <returns></returns>
        public Task<IActionResult> Logout();
    }
}