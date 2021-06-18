using Meetup.ApplicationDbContext.Model;
using Meetup.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meetup.Interfaces
{
    public interface IAdminService
    {
        /// <summary>
        /// получение всех пользователей
        /// </summary>
        /// <returns>коллекция пользователей</returns>
        Task<ICollection<User>> GetAllUsersAsync();
        /// <summary>
        /// получить пользвателя по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>пользователь</returns>
        Task<User> GetUserByIdAsync(string id);
        /// <summary>
        /// Получить всех пользлвателей в метапе
        /// </summary>
        /// <param name="id">ID Meetup</param>
        /// <returns>Users</returns>
        Task<ICollection<UserViewModel>> GetUsersInMeetupAsync(string id);
    }
}