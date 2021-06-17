using Meetup.Interfaces.Dtos;
using Meetup.ViewModels;
using System.Threading.Tasks;

namespace Meetup.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegistrationAsync(UserDto userDto);
        Task<bool> ConfirmationEmail(string userId, string code);
    }
}