using Meetup.Interfaces.Dtos;
using System.IO;
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
        Task CreateMeetup(MeetupDto meetupDto, Stream stream);
    }
}