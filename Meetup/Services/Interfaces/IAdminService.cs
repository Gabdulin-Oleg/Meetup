using Meetup.ApplicationDbContext.Model;
using System.Collections.Generic;

namespace Meetup.Services.Interfaces
{
    public interface IAdminService
    {
        /// <summary>
        /// получение всех пользователей
        /// </summary>
        /// <returns>коллекция пользователей</returns>
        ICollection<User> GetAllUsers();
        /// <summary>
        /// получить пользвателя по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>пользователь</returns>
        User GetUserById(int id);
    }
}