using Meetup.Interfaces.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meetup.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        Task<bool> RegistrationAsync(UserDto userDto);
        /// <summary>
        /// Подтверждение Email
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<bool> ConfirmationEmail(string userId, string code);
        /// <summary>
        /// Подписаться на метап
        /// </summary>
        /// <param name="meetupId"></param>
        /// <returns></returns>
        Task SignUpMeetup(string meetupId);
        /// <summary>
        /// Создать Метап
        /// </summary>
        /// <param name="meetupDto"></param>
        /// <param name="meetupLocationId"></param>
        /// <returns></returns>
        Task<bool> CreateMeetup(MeetupDto meetupDto);
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