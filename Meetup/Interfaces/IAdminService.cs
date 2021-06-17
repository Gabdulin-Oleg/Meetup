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
        Task<User> GetUserByIdAsync(int id);
        Task<ICollection<UserViewModel>> GetUsersInMeetupAsync(int id);
    }
}