using System.Threading.Tasks;

namespace Meetup.Services.Interfaces
{
    public interface IEmailSender
    {

        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}