using Meetup.ApplicationDbContext.Model;
using Meetup.Interfaces.Dtos;
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
        Task<ICollection<UserDto>> GetAllUsersAsync();
        /// <summary>
        /// получить пользвателя по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>пользователь</returns>
        Task<UserDto> GetUserByIdAsync(string id);
        /// <summary>
        /// Получить всех пользлвателей в метапе
        /// </summary>
        /// <param name="id">ID Meetup</param>
        /// <returns>Users</returns>
        Task<ICollection<UserDto>> GetUsersInMeetupAsync(string id);
        /// <summary>
        /// получить все метапы
        /// </summary>
        /// <returns></returns>
        Task<ICollection<MeetupDto>> GetAllMeetupsAsync();
        /// <summary>
        /// получить метап по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MeetupDto> GetMeetupById(string id);
        /// <summary>
        /// Создать место проведения метапа
        /// </summary>
        /// <param name="meetupLocationDto"></param>
        /// <returns></returns>
        Task CreateMeetupLocation(MeetupLocationDto meetupLocationDto);
        /// <summary>
        /// Получить все места метапа
        /// </summary>
        /// <returns></returns>
        Task<ICollection<MeetupLocationDto>> GetAllMeetupLocationAsync();
        /// <summary>
        /// получить место метапа по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MeetupLocationDto> GetMeetupLocationByIdAsync(string id);
    }
}